using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections.Generic;

/*
The PrintCode class is used to print off serial numbers for a given product in
the form of a QR code. When using this class, a temp folder may be generated
in the program's directory. This folder can be safely deleted when the program
is not currently printing images. 
*/
public class PrintCode {
    private List<string> _serialNumbers;
    private int _fontSize;
    private float _qrscale;
    private string _fontName, _printerName;
    private Point _fontLocation, _qrLocation;
    private bool _showLabel;
    /*
    The PrintCode constructor configures the defualt print settings.
    */
    public PrintCode() {
        this._serialNumbers = new List<string>();
        this._qrscale = 0.5f; 
        this._fontSize = 14;
        this._fontName = "Verdana";
        this._fontLocation = new Point(120, 30);
        this._qrLocation = new Point(0, 0);
        this._printerName = null; // Send to default windows printer
        this._showLabel = true;
    }
    /*
    (int) Print attempts to print all of the serial numbers sitting in the
    (List<string>) _serialNumbers list. If the flag (bool) includeLabel is
    set to false when print is called, a label will not be printed alongside
    the QR code. 

    On success, 0 is returned and all serial numbers sitting in the
    (List<string>) _serialNumbers list are printed off. On failure,
    -1 is returned and an indeterminate number of serial numbers
    are printed off.
    */
    public int Print() {
        int returnCode = 0;
        this._serialNumbers.ForEach((string serialNumber) => {
            try {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (object o, PrintPageEventArgs e) => {
                    Zen.Barcode.CodeQrBarcodeDraw qr = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    Image img = qr.Draw(serialNumber, 20);
                    Point location = this._qrLocation;
                    Bitmap scaledImage = new Bitmap(img, (int)(img.Width * this._qrscale), (int)(img.Height * this._qrscale));
                    e.Graphics.DrawImage((Image)scaledImage, location);
                    if (this._showLabel) {
                        Font font = new Font(this._fontName, this._fontSize);
                        e.Graphics.DrawString("SN: " + serialNumber, font, Brushes.Black, this._fontLocation);
                    }
                };
                if (this._printerName != null) {
                    pd.PrinterSettings.PrinterName = this._printerName; // Change to name of printer
                }
                pd.DefaultPageSettings.Landscape = true; // Leave as true for now 
                Console.WriteLine("Printing to: " + pd.PrinterSettings.ToString());
                pd.Print();
            } catch (Exception e) {
                MessageBox.Show("Error: " + e.ToString());
                returnCode = -1;
            }
        });
        return returnCode;
    }

    /*
    (List<string>) getSerialNumbers returns the list of serial numbers in the object.
    */
    public List<string> GetSerialNumbers() => this._serialNumbers;

    /*
    (List<string>) getPrinters returns a (List<string>) printerList containing
    the names of all of the printers detected by the Windows machine. 
    */
    static public List<string> GetPrinters() {
        List<string> printerList = new();
        foreach (string s in PrinterSettings.InstalledPrinters)
        {
            printerList.Add(s);
        }
        return printerList;
    }

    /*
    (string) getPrinter returns the name of the currently selected printer.
    */
    public string GetPrinter()
    {
        if (this._printerName != null)
            return this._printerName;
        else
        {
            PrintDocument pd = new PrintDocument();
            return pd.DefaultPageSettings.PrinterSettings.PrinterName;
        }
    }


    /*
    (bool) setPrinter takes a (string) printerName and sets the given
    printerName to the current printer to use. If the printer does not
    exist, false is returned and the printer is not changed. If the
    printer was successfully changed, true is returned. 
    */
    public bool SetPrinter(string printerName) {
        if (GetPrinters().Contains(printerName)) {
            this._printerName = printerName;
            return true;
        }
        return false;
    }

    /*
    (void) setQRLocation takes (int) x and (int) y values representing the
    x-y location of the QR code, where the origin is placed in the upper
    left corner. By default, this value is set to the origin (0,0).
    */
    public void SetQRLocation(int x, int y) => this._qrLocation = new Point(x, y);

    public Point GetQRLocation() => this._qrLocation;
    /*
    (void) setFontLocation takes (int) x and (int) y values representing the
    x-y location of the text label, where the origin is placed in the upper
    left corner. 
    */
    public void SetLabelLocation(int x, int y) => this._fontLocation = new Point(x, y);

    public Point GetLabelLocation() => this._fontLocation;

    /*
    (void) setFontSize sets the size of the font on the labels being printed.
    */
    public void SetFontSize(int fontSize) => this._fontSize = fontSize > 0 ? fontSize : 1;

    public float GetFontSize() => this._fontSize;


    /*
    (void) SetFont sets the font to be used for the labels being printed.
    */
    public void SetFontName(string fontName) => this._fontName = fontName;

    public string GetFontName() => this._fontName;

    /*
    (void) SetScale sets the scale for the QR code defined by the given
    (float) scale. For example, the scale value 1.0 sets the scale to 100%, 
    and 0.5 sets the scale to 50%. The scale value is applied when print()
    is called. 
    */
    public void SetScale(float scale) => this._qrscale = scale > 0 ? scale : 1.0f;

    public float GetScale() => this._qrscale;

    public void SetLabelUse(bool useLabel) => this._showLabel = useLabel;

    public bool GetLabelUse() => this._showLabel;

    public Image GetTestImage()
    {
        string dummySN = "Hello World!";
        Zen.Barcode.CodeQrBarcodeDraw qr = Zen.Barcode.BarcodeDrawFactory.CodeQr;
        Image img = qr.Draw(dummySN, 20);
        Point location = this._qrLocation;
        Bitmap scaledImage = new Bitmap(img, (int) (img.Width * this._qrscale), (int) (img.Height * this._qrscale));
        Bitmap translatedImage = new Bitmap((int) (img.Width * this._qrscale) + location.X,
            (int) (img.Height * this._qrscale) + location.Y);
        Graphics transform = Graphics.FromImage(translatedImage);
        transform.TranslateTransform(location.X, location.Y);
        transform.DrawImage(scaledImage, new Point(0, 0));
        transform.Dispose(); // Delete temp transform graphic
        return translatedImage;
    }
    /*
    (void) AddSerial takes a (string) serialNumber and adds it to the
    (List<string>) _serialNumbers list to be printed off in the next
    call to print().
    */
    public void AddSerial(string serialNumber) => this._serialNumbers.Add(serialNumber);

    /*
    (void) CleanUp function clears out the (List<string>) _serialNumbers list.
    */
    public void CleanUp() => this._serialNumbers.Clear();

    /*
    (void) ShowList, when called, brings up a message box for the user to
    quickly see which serial numbers are currently pending to be printed. 
    */
    public void ShowList() {
        string pending = String.Join("\n", this._serialNumbers.ToArray());
        MessageBox.Show("Serial numbers currently pending print:\n\n" + pending);
    }
} 
