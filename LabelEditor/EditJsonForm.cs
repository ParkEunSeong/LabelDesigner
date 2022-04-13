using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public partial class EditJsonForm : Form
    {
        public EditJsonForm()
        {
            InitializeComponent();
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            
        }
        private string m_loadFileName;
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                m_loadFileName = dlg.FileName;
                using (var sr = new StreamReader(m_loadFileName))
                {
                    var r = sr.ReadToEnd();
                    var j = JObject.Parse(r);
                    textBox1.Text = j.ToString();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter(m_loadFileName))
            {
                sw.Write(textBox1.Text);
            }
        }
    }
}
