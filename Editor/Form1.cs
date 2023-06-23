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
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            EditorRichTextBox.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.InitialDirectory = @"c:\";
            opendialog.Multiselect = false;
            opendialog.DefaultExt = "txt";
            DialogResult result = opendialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string extension = Path.GetExtension(opendialog.FileName);
                if (extension == "txt")
                {

                }
                else
                {

                    MessageBox.Show(extension);
                }


            }

        }
    }
}
