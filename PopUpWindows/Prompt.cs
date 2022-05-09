using System.Windows.Forms;

/*
    This is a smaller form that pops up to take an input from the user allowing them to submit a text response or cancel.
    The general nature of this Form can be reused elsewhere.
    */
public class Prompt : Form
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Size = new System.Drawing.Size(500, 350);
            prompt.StartPosition = FormStartPosition.CenterParent;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;

            TextBox inputBox = new TextBox();
            Button confirm = new Button();
            Button reject = new Button();

            inputBox.Size = new System.Drawing.Size(400, 150);
            inputBox.Location = new System.Drawing.Point(50, 50);
            inputBox.Multiline = true;
            inputBox.Text = text;    

            confirm.Text = "Submit";
            confirm.Size = new System.Drawing.Size(100, 25);
            confirm.Location = new System.Drawing.Point(150, 215);
            confirm.DialogResult = DialogResult.OK;

            reject.Text = "Cancel";
            reject.Size = new System.Drawing.Size(100, 25);
            reject.Location = new System.Drawing.Point(275, 215);

            confirm.Click += (sender, e) => { prompt.Close(); };
            reject.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirm);
            prompt.Controls.Add(reject);
            prompt.AcceptButton = null;
            prompt.CancelButton = reject;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        } // ShowDialog()
    } // Prompt : Form
