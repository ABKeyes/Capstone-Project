using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*
 The static CSV class is used to persist a CSVCreator instance across pages so
 that its contents are not flushed in-between searches or page changes.
*/
static public class CSV {
    public static CSVCreator data = new CSVCreator();
}

/*
 The CSVCreator class is used to select and export batches of serial numbers
 into a CSV file. The exported CSV file has a single column containing different
 serial numbers saved into the CSVCreator instance. Methods for this class are
 briefly defined below, but for a more thorough definition please check the
 comment blocks above each respective method:

 * CSVCreator() - Constructor, initializes the internal set of serial numbers.
 * (void) addSerialNumber(serialNum) - Adds the given (String) serialNum
   to the internal (HashSet<String>) data set of serial numbers.
 * (void) addSerialNumbers(serialNums) - Adds the given 
   (List<String>) serialNums to the internal set of serial numbers for the
   CSVCreator instance. 
 * (void) removeSerialNumber(serialNum) - Removes the given (String) serialNum
   serial number from the internal set of serial numbers.
 * (void) removeSerialNumbers() - Removes all serial numbers from the internal
   (HashSet<String>) data set of serial numbers.
 * (String[]) getNumbers() - Returns the set of serial numbers contained in the
   internal (HashSet<String>) data as an array of strings.
 * (void) exportCSV() - Exports the serial numbers contained in the internal
   (HashSet<String>) data CSVCreator data structure to a CSV file. This method
   prompts the user for a location to save the CSV file at. 
*/
public class CSVCreator {
    // Set of serial numbers - no duplicates
    private HashSet<String> data;

    /*
     CSVCreator initializes the (HashSet<String>) data set.
    */
    public CSVCreator() {
        this.data = new HashSet<String>();
    }

    /*
     (void) addSerialNumber takes a (String) serialNum and adds it to the
     private (HashSet<String>) data set.
    */
    public void addSerialNumber(String serialNum) {
        this.data.Add(serialNum);
    }

    /*
     (void) addSerialNumbers takes a (List<String>) serialNums and adds each
     serial number provided in (List<String>) serialNums in sequence to the
     private (HashSet<String>) data set. 
    */
    public void addSerialNumbers(List<String> serialNums) {
        foreach (String s in serialNums) {
            this.data.Add(s);
        }
    }

    /*
     (void) removeSerialNumber removes the given (String) serialNum from the
     private (HashSet<String>) data set. 
    */
    public void removeSerialNumber(String serialNum) {
        try {
            this.data.Remove(serialNum);
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    /*
     (void) removeSerialNumbers clears the (HashSet<String>) data set, removing
     all serial numbers from the list.
    */
    public void removeSerialNumbers() {
        this.data.Clear();
    }

    /*
     (String[]) getNumbers returns a String array representation of all of the
     serial numbers stored in the (HashSet<String>) data set.
    */
    public String[] getNumbers() {
        List<String> numbers = new List<String>();
        foreach (String s in this.data) {
            numbers.Add(s);
        }
        return numbers.ToArray();
    }

    /*
     (void) exportCSV generates a CSV file and prompts the user where to save it
     to upon calling. Once the user has selected where to export the CSV file,
     it is written to that location.

     CSV files generated using this method have the following format for each
     entry:

     serialNum,\n...

     This results in the generated CSV consisting of a single column of serial
     numbers to be fed to the Brady printing software.
    */
    public void exportCSV() {
        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Filter = "Comma-separated values (.csv)|*.csv";
        saveDialog.Title = "Export CSV File";
        saveDialog.ShowDialog();
        if (saveDialog.FileName != "") {
            FileStream fs = (FileStream)saveDialog.OpenFile();
            string csvoutput = ""; // Build CSV string
            foreach (String s in this.data) {
                csvoutput += s + ",\n";
            }
            byte[] output = Encoding.ASCII.GetBytes(csvoutput);
            fs.Write(output, 0, output.Length);
            fs.Close();
        }
    }
}