using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CapstoneApp
{
    public partial class PrintSettings : Form
    {
        private SqlConnectionStringBuilder _builder;
        private string _dummySN = "Hello World!";
        private bool reset = false;
        public PrintSettings(SqlConnectionStringBuilder connection)
        {
            this.InitializeComponent();
            this._builder = connection;
            this.Show();
            this.printerBox.Items.AddRange(PrintCode.GetPrinters().ToArray());
            this.UpdatePreview();
            this.useLabelBox.Click += (o, e) =>
            {
                this.SaveInfo();
            };
            this.printerBox.TextChanged += (o, e) =>
            {
                this.SaveInfo();
                Console.WriteLine("Printer changed to " + PrinterInfo.printer.GetPrinter());
            };
            // Give special settings to every textbox
            foreach (TextBox t in this.Controls.OfType<TextBox>())
            {
                t.TextChanged += (o, e) =>
                {
                    if (reset) return;
                    // Automatically sanitize input
                    List<char> sanitized = new List<char>();
                    foreach (char c in t.Text)
                    {
                        // Check that each character is legal
                        if (c >= 48 && c <= 57) sanitized.Add(c);
                    }
                    if (sanitized.Count > 0)
                    {
                        t.Text = string.Join("", sanitized.ToArray());
                        this.SaveInfo();
                    }
                    else
                    {
                        // No input = 0
                        t.Text = "0";
                    }
                    
                };
            }
        }

        private void QuitButton_Click(object sender, EventArgs e) => this.Close();

        private void UpdatePreview()
        {
            this.labelSizeBox.Text = PrinterInfo.printer.GetFontSize().ToString();
            this.labelLocationXBox.Text = PrinterInfo.printer.GetLabelLocation().X.ToString();
            this.labelLocationYBox.Text = PrinterInfo.printer.GetLabelLocation().Y.ToString();
            this.qrSizeBox.Text = (PrinterInfo.printer.GetScale() * 100).ToString();
            this.qrLocationXBox.Text = PrinterInfo.printer.GetQRLocation().X.ToString();
            this.qrLocationYBox.Text = PrinterInfo.printer.GetQRLocation().Y.ToString();
            this.previewBox.Image = PrinterInfo.printer.GetTestImage();
            this.printerBox.Text = PrinterInfo.printer.GetPrinter();
            this.useLabelBox.Checked = PrinterInfo.printer.GetLabelUse();
            this.labelLabel.Text = this.useLabelBox.Checked ? "SN: " + this._dummySN : "";
            this.labelLabel.Location = new Point(
                 this.previewBox.Location.X + PrinterInfo.printer.GetLabelLocation().X,
                 this.previewBox.Location.Y + PrinterInfo.printer.GetLabelLocation().Y);
            this.labelLabel.Font = new Font(PrinterInfo.printer.GetFontName(), PrinterInfo.printer.GetFontSize());

        }

        private void SaveInfo()
        {
            PrinterInfo.printer.SetFontSize(int.Parse(this.labelSizeBox.Text));
            PrinterInfo.printer.SetLabelLocation(int.Parse(this.labelLocationXBox.Text),
                int.Parse(this.labelLocationYBox.Text));
            PrinterInfo.printer.SetScale(float.Parse(this.qrSizeBox.Text) / 100.0f);
            PrinterInfo.printer.SetQRLocation(int.Parse(this.qrLocationXBox.Text),
                int.Parse(this.qrLocationYBox.Text));
            PrinterInfo.printer.SetPrinter(this.printerBox.Text);
            PrinterInfo.printer.SetLabelUse(this.useLabelBox.Checked);
            this.UpdatePreview();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            reset = true;
            // Replace old printer instance with new one to reset
            PrinterInfo.printer = new PrintCode();
            this.UpdatePreview();
            reset = false;
        }

        private void TestPrint_Click(object sender, EventArgs e)
        {
            PrinterInfo.printer.AddSerial(this._dummySN);
            PrinterInfo.printer.Print();
            PrinterInfo.printer.CleanUp();
        }
    }
    public static class PrinterInfo
    {
        public static PrintCode printer = new PrintCode();
    }

}
