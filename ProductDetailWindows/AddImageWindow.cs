using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;


namespace CapstoneApp.ProductDetailWindows
{
    public partial class AddImageWindow : UserControl
    {
        public SqlConnectionStringBuilder _builder;
        public static string SerialNumber
        {
            get; set;
        }
        private string _serialNumber, _imageName;
        public string LotNum
        {
            get; set;
        }
        string workingDirectory;
        string firstimage = null, Filename = null, checkingFolder = null;
        int forward = 0;
        FileStream firstfile;
        bool LotNumexists = false;
        public AddImageWindow(SqlConnectionStringBuilder connection, string serialNumber)
        {
            this._builder = connection;
            this.Size = new System.Drawing.Size(950, 560);
            SerialNumber = serialNumber;
            this._serialNumber = serialNumber;
            this.InitializeComponent();
            SetFristImage();



        }
        public void SetFristImage()
        { 
            // creating directory 
            workingDirectory = Environment.CurrentDirectory;
            string folderName = @"\ProductImages";


            workingDirectory = workingDirectory + folderName; // creatig image folder
            System.IO.Directory.CreateDirectory(workingDirectory);
            string LotNumFOlderName = GetLotNumOfProduct(SerialNumber);// geting the lot number for this serial num
            if (LotNumFOlderName != "")
            {
                LotNumexists = true;
                LotNumFOlderName = @"\" + LotNumFOlderName;
                workingDirectory = workingDirectory + LotNumFOlderName;
                System.IO.Directory.CreateDirectory(workingDirectory); // serial num folder created is already created then do nothing
                string SerialNumberlink = @"\" + SerialNumber;
                checkingFolder = workingDirectory + SerialNumberlink;
                if (Directory.Exists(checkingFolder)) // checking whther directory exist or not if yes select image and save i in image box
                {
                     
                    DirectoryInfo di = new DirectoryInfo(checkingFolder);
                    var firstFileName = di.EnumerateFiles().Select(f => f.Name).FirstOrDefault();
                    firstimage = checkingFolder + @"\" + firstFileName;
                    string imageexists = Path.GetFileName(firstimage); // checking if there is any image save in that folder or not
                    if (imageexists != "" && imageexists != null)
                    {
                        FileInfo imageFileinfo;
                        Image img = new Bitmap(firstimage);
                        imageFileinfo = new FileInfo(firstimage);
                        // this.mainPictureBox.Image = new Bitmap(firstimage);
                        this.mainPictureBox.Tag = firstimage;
                        this.mainPictureBox.ImageLocation = firstimage;
                        mainPictureBox.Image = img.GetThumbnailImage(350, 350, null, new IntPtr());
                        img.Dispose();


                    }
                   
                    // firstimage="";
                }
            }
                else
                {
                    LotNumexists = false;


                }
            


        }
        private void SelectOnClick(object sender, EventArgs e)
        {

            string filePath = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png)|*.jpg; *.jpeg; *.bmp; *.png|All files(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    _imageName = Path.GetFileName(ofd.FileName);
                    Filename = ofd.FileName;
                    this.mainPictureBox.Image = new Bitmap(ofd.FileName);
                    this.mainPictureBox.ImageLocation = ofd.FileName;


                }
            }


        }

        private void Moveleft_Click(object sender, EventArgs e)
        {

            forward = forward - 1;
            if (forward < 0)
            {
                forward = 0;
            }

            DirectoryInfo di = new DirectoryInfo(checkingFolder);

            List<string> firstFileName = di.EnumerateFiles().Select(f => f.Name).ToList();
            if (firstFileName.Count > 1)
            {
                var nextimage = firstFileName.Skip(forward).FirstOrDefault();

                if (nextimage != "" || nextimage != null)
                {
                    nextimage = checkingFolder + @"\" + nextimage;
                    FileInfo imageFileinfo;
                    Image img = new Bitmap(nextimage);
                    imageFileinfo = new FileInfo(nextimage);
                    // this.mainPictureBox.Image = new Bitmap(firstimage);
                    this.mainPictureBox.Tag = nextimage;
                    this.mainPictureBox.ImageLocation = nextimage;
                    mainPictureBox.Image = img.GetThumbnailImage(350, 350, null, new IntPtr());
                    img.Dispose();
                }
            }
        }

        private void moveRight_Click(object sender, EventArgs e)
        {

           //for moving image right it will add the number to move forward
            forward = forward + 1;

            DirectoryInfo di = new DirectoryInfo(checkingFolder);
//converting string to directory to access the images a that location
            List<string> firstFileName = di.EnumerateFiles().Select(f => f.Name).ToList();
            //image was store in list
            // conditioning on list if it was not empty
            if (firstFileName.Count > 1)
            {
                var nextimage = firstFileName.Skip(forward).FirstOrDefault();//selectong the next image from list
            
                if (nextimage != "" && nextimage != null)
                {
                    nextimage = checkingFolder + @"\" + nextimage;
                    FileInfo imageFileinfo;
                    Image img = new Bitmap(nextimage);
                    imageFileinfo = new FileInfo(nextimage);
                    // this.mainPictureBox.Image = new Bitmap(firstimage);
                    this.mainPictureBox.Tag = nextimage;
                    this.mainPictureBox.ImageLocation = nextimage;
                    mainPictureBox.Image = img.GetThumbnailImage(350, 350, null, new IntPtr());
                    img.Dispose();
                    //image was loaded 



                }
                // if there was not futher image the funtion will not move formard more 
                else if (firstFileName.Count - 1 < forward)
                {
                    forward = firstFileName.Count - 1;
                }
            }

        }

        private void InsertOnClick(object sender, EventArgs e)
        {
            //check whether the lotnum is avalible or not
            if (LotNumexists)
            {
                //checking image is avalible to insert or not or new imags is slected to insert or not
                if (_imageName != "" && _imageName != null)
                {
                       //create a folder of serial number
                    string SerialNumberlink = @"\" + SerialNumber;
                    string imagesavelink = workingDirectory + SerialNumberlink;
                    System.IO.Directory.CreateDirectory(imagesavelink);
                   
                    var path = Path.Combine(imagesavelink, _imageName);
                    //file.SaveAs(path);
                    this.mainPictureBox.ImageLocation=path;
                    File.Copy(Filename, path, true);
                    // image was saved in serial number folder
                    MessageBox.Show(" New Image INSERTED successfully");
                    imagesavelink = "";

                }
                else
                {
                    if (firstimage != "")
                    {
                        MessageBox.Show("Please select New Image To INSERT");
                    }
                    else
                    {
                        MessageBox.Show("Please select Image To INSERT");

                    }
                }
            }
            else
            {
                MessageBox.Show("No LotNum Allocaed For this Product");
            }


        }

        private void DeleteImageBtn_Click(object sender, EventArgs e)
        {
            // select the image from picture box and save it location
            var deleteImage = this.mainPictureBox.ImageLocation;

       // checking that image is save in this application it will not allow to delete the image from perosnal system which was not inserted yet
            if (deleteImage.Contains("capstoneapp") && deleteImage != "" && deleteImage != null)
            {
                //_imageName = Path.GetFileName(deleteImage);
                if (File.Exists(deleteImage))
                {
                    //clear the image location and image from screnn
                    this.mainPictureBox.Image.Dispose();
                    this.mainPictureBox.Image = null;
                    this.mainPictureBox.ImageLocation = null;
                    this.mainPictureBox.Update();
                    //delete the image
                    File.Delete(deleteImage);

                    //reader.Close();
                    MessageBox.Show("Image deleted");
                    //after deleting the first image was selected from list and shown
                    SetFristImage();
                }

            }
            else
            {

                MessageBox.Show("No Image Found TO delete");
            }


        }


        // this funtion will return the lot num for each serial number provided 
        public string GetLotNumOfProduct(string SerialNumberobj)
        {

            string _LotNum = "";
            try
            {

                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                connection.Open();
                string updateQuery = "Select LotNum FROM Product  WHERE ProductSN = @ProductSN";
                SqlCommand productCommand = new SqlCommand(updateQuery, connection);

                productCommand.Parameters.AddWithValue("@ProductSN", SerialNumberobj);

                _LotNum = productCommand.ExecuteScalar().ToString();




                connection.Close();


            }
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());

            }
            return _LotNum;

        }

    }
}
