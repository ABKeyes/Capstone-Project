using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

class AligniLocation {
    public String name {get; set;}
    public String id {get; set;}
}

class QueryData {
    public String id {get; set;}
    public String unit_id {get; set;}
    public Boolean status {get; set;}
    public HttpResponseMessage msg {get; set;}
    public List<AligniLocation> locations = new List<AligniLocation>();
}

/*
Usage for Aligni communication using class AAPI (Aligni API):
AAPI myClass = new AAPI();
Console.WriteLine("Show general data for a part (restricted to part 728 currently):");
String x = await c.getGeneralPartData(0);
Console.WriteLine(x); //OR Console.Write(await c.getGeneralPartData(0));

Console.WriteLine("Show Revision data for a part (restricted to part 728 currently):");
String y = await c.getRevisionData(0);
Console.WriteLine(y); //OR Console.Write(await c.getRevisionData(0));

Console.WriteLine("Show Part type data for a parttype (restricted to parttype 47)");
String z = await c.getPartTypeData(0);
Console.WriteLine(z); //OR Console.Write(await c.getPartTypeData(0));
*/

/*
This Class is one of the first steps to communicating with Aligni while making use of their API
and parsing the data that is returned as XML.
*/
class AAPI{

    private static readonly HttpClient _client = new HttpClient();
    private String _errStr = "Error retrieving data.";
    private Task<string> _stringTask;
    private String _msg;
    private String _response = "";
    private XmlDocument _xmlDoc = new XmlDocument();
    private QueryData queryResult = null;
    public async Task<String> getGeneralPartData(string x){
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

        try{
            _stringTask = _client.GetStringAsync("https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/part/" + x);
            _msg = await _stringTask;
            _xmlDoc.LoadXml(_msg);
            String xmlPath = "part";
            XmlNode root = _xmlDoc.SelectSingleNode(xmlPath);
            queryResult = new QueryData();
            foreach(XmlNode childNode in root){
                if(childNode.Name == "revision"){
                    break;
                }
                else if(!childNode.InnerText.Equals("")){
                    _response += $"{childNode.Name}: {childNode.InnerText} \r";
                }
                switch (childNode.Name) {
                    case "unit_id":
                        queryResult.unit_id = childNode.InnerText;
                        break;
                    case "id":
                        queryResult.id = childNode.InnerText;
                        break;
                    default:
                        break;
                }
            }
        }//try
        catch(System.Net.Http.HttpRequestException e){
            _msg = e.ToString();
            Console.WriteLine(_msg);
            _response = _errStr;
            queryResult = null;
        }//catch(System.Net.Http.HttpRequestException e)
        return _response;
    }//getGeneralPartData()
    public async Task<String> getStorageLocations() {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

        try{
            _stringTask = _client.GetStringAsync("https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/inventory_location?page=0&per_page=0");
            _msg = await _stringTask;
            _xmlDoc.LoadXml(_msg);
            String xmlPath = "inventory_locations/inventory_location";
            XmlNodeList root = _xmlDoc.SelectNodes(xmlPath);
            queryResult = new QueryData();
            foreach(XmlNode parentNode in root) {
                AligniLocation currentLocation = new AligniLocation();
                foreach(XmlNode childNode in parentNode) {
                    switch (childNode.Name) {
                        case "name":
                            currentLocation.name = childNode.InnerText;
                            break;
                        case "id":
                            currentLocation.id = childNode.InnerText;
                            break;
                        default:
                            break;
                    }
                    //Console.WriteLine($"{childNode.Name}: {childNode.InnerText}");
                }
                // Add current location to list of locations
                queryResult.locations.Add(currentLocation);
            }
            
        }//try
        catch(System.Net.Http.HttpRequestException e){
            _msg = e.ToString();
            Console.WriteLine(_msg);
            _response = _errStr;
        }//catch(System.Net.Http.HttpRequestException e)
        return _response;
    }//getGeneralPartData()

    public QueryData getResult() {
        return queryResult;
    }
    public async Task<String> getRevisionData(int x){
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

        try{
            _stringTask = _client.GetStringAsync("https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/parts/728/revisions");
            _msg = await _stringTask;
            _xmlDoc.LoadXml(_msg);
            String xmlPath = "part_revisions/part_revision";
            XmlNodeList xmlNodes = _xmlDoc.SelectNodes(xmlPath);

            foreach(XmlNode childNode in xmlNodes){
                if(childNode.FirstChild.HasChildNodes){
                    foreach(XmlNode cNode in childNode){
                        if(!cNode.InnerXml.Equals("")){
                            _response += $"{cNode.Name}: {cNode.InnerXml} \r";
                        }
                    }
                }
            }
        }//try
        catch(System.Net.Http.HttpRequestException e){
            _msg = e.ToString();
            Console.WriteLine(_msg);
            _response = _errStr;
        }//catch(System.Net.Http.HttpRequestException e)
        return _response;
    }//getRevisionData()

    public async Task<String> getPartTypeData(int x){
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

        try{
            _stringTask = _client.GetStringAsync("https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/parttype/47");
            _msg = await _stringTask;
            _xmlDoc.LoadXml(_msg);
            String xmlPath = "parttype";
            XmlNodeList xmlNodes = _xmlDoc.SelectNodes(xmlPath);

            foreach(XmlNode childNode in xmlNodes){
                if(childNode.FirstChild.HasChildNodes){
                    foreach(XmlNode cNode in childNode){
                        if(!cNode.InnerXml.Equals("")){
                            _response += $"{cNode.Name}: {cNode.InnerXml} \r";
                        }
                    }
                }
            }
        }//try
        catch(System.Net.Http.HttpRequestException e){
            _msg = e.ToString();
            Console.WriteLine(_msg);
            _response = _errStr;
        }//catch(System.Net.Http.HttpRequestException e)
        return _response;
    }//getPartTypeData()

    public async Task<String> getInventoryData(int x)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

        try
        {
            _stringTask = _client.GetStringAsync("https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/part/000238?find_by=partnumber");
            _msg = await _stringTask;
            _xmlDoc.LoadXml(_msg);
            Console.WriteLine(_msg);
            String xmlPath = "part";
            XmlNodeList xmlNodes = _xmlDoc.SelectNodes(xmlPath);

            foreach (XmlNode childNode in xmlNodes)
            {
                if (childNode.FirstChild.HasChildNodes)
                {
                    foreach (XmlNode cNode in childNode)
                    {
                        if (!cNode.InnerXml.Equals(""))
                        {
                            _response += $"{cNode.Name}: {cNode.InnerXml} \r";
                        }
                    }
                }
            }
        }//try
        catch (System.Net.Http.HttpRequestException e)
        {
            _msg = e.ToString();
            Console.WriteLine(_msg);
            _response = _errStr;
        }//catch(System.Net.Http.HttpRequestException e)
        return _response;
    }//getRevisionData()

    public async Task<String> UpdateInventory(string part_id, int quantity, string unit_id, String serialNumber, String dateCode, String lotcode, int sublocation_id=1)
    {
        /*
        
         curl \
        https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/parts/773/inventory_units \
          -d "inventory_unit[quantity]"="1" \
          -d "inventory_unit[unit_id]"="2" \
          -d "inventory_unit[inventory_sublocation_id]"="2" \
          -d "inventory_unit[cost_per_unit]"="0" \
          -d "inventory_unit[asset_id]"="" \
          -d "inventory_unit[serial_number]"="" \
          -d "inventory_unit[datecode]"="" \
          -d "inventory_unit[lot_code]"="" \
          -d "inventory_unit[sublocation_bin]"="" \
          -d "inventory_unit[details]"="" \
          -d "inventory_unit[purchase_order_number]"="" \
          -d "inventory_unit[generate_asset_id]"="" \
          -d "inventory_unit[inventory_record][comment]"="" \
          -X POST
         */
        FormUrlEncodedContent stringContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("inventory_unit[quantity]", quantity.ToString()),
            new KeyValuePair<string, string>("inventory_unit[unit_id]", unit_id),
            new KeyValuePair<string, string>("inventory_unit[inventory_sublocation_id]", sublocation_id.ToString()),
            new KeyValuePair<string, string>("inventory_unit[serial_number]", serialNumber),
            new KeyValuePair<string, string>("inventory_unit[lot_code]", lotcode),
            new KeyValuePair<string, string>("inventory_unit[datecode]", dateCode),
        });
        HttpResponseMessage msg = await _client.PostAsync("https://demo.aligni.com/api/v2/oid3vLgynoy_Yl1gZkrgkLEq3J/parts/" + part_id + "/inventory_units", stringContent);
        
        //Console.WriteLine(msg.Content.ToString());
        //Console.WriteLine(msg);
        queryResult = new QueryData();
        if (msg.StatusCode != System.Net.HttpStatusCode.OK) {
            queryResult.status = false;
        } else {
            queryResult.status = true;
        }
        queryResult.msg = msg;
        return "Done";
    }
}

/*
    Places of Interest based off of demo database Documentation for Aligni https://api.aligni.com/v2/index.html#object_build
    *Attachments: Files, notes and URLS associated with various parent objects.
    *Builds: Can have relevant build info that might be of interest to company.
    *Parts: Relevant data to an object.
    *Part Revisions: Relevant data such as number of revisions, comments and descriptions.
    *Quotes: May be useful in the Fishbowl communication.
    *PartType: Categories of parts in the item master.
*/
