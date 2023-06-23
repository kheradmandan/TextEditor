using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class Form1 : Form
    {
        private string _filename = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _filename = null;
            EditorRichTextBox.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.InitialDirectory = @"c:\";
            opendialog.Multiselect = false;
            opendialog.DefaultExt = "txt";
            DialogResult result = opendialog.ShowDialog();



            if (result == DialogResult.OK && opendialog.FileName.Contains(".txt"))
            {
                string strTxt = opendialog.FileName;
                EditorRichTextBox.Text = File.ReadAllText(strTxt);


            }

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (_filename == null)
            {
                if (!SaveFileDialog())
                {
                    MessageBox.Show("ذخیره فایل با خطا مواجه شد");
                    return;
                }

            }
            SaveFile(_filename);
            MessageBox.Show("فایل با موفقیت ذخیره شد");
            _filename = null;
            EditorRichTextBox.Clear();
        }



        private bool SaveFileDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = "txt";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                    return true;
                }
                else
                    return false;
            }
        }

        private void SaveFile(string filename)
        {

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    // writing data in string
                    string dataasstring = EditorRichTextBox.Text;
                    byte[] info = new UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);

                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
    

            //using (StreamWriter writer = File.CreateText(filename))
            //{
            //    writer.Write(EditorRichTextBox.Text);
            //    writer.Flush();
            //    writer.Close();
            //}


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void EditorRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
