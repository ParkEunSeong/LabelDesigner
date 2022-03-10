using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json;
using LabelEditor.data;

namespace LabelEditor
{
    public partial class frmMain : Form
    {
        // Interface Type
        public const int ISerial    = 0;
        public const int IParallel  = 1;
        public const int IUsb       = 2;
        public const int ILan       = 3;
        public const int IBluetooth = 5;
        public LabelConfiguration m_configuration;
        private Form1 m_designForm;
        
        private Paper m_paper;
        public frmMain()
        {
            InitializeComponent();
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");
        }
        public void SetData( string data )
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            try
            {
                StringBuilder strVersion = new StringBuilder(256);

                Text = "LabelDesigner v1.0.0";

            }
            catch (System.Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void rdoIF_Serial_CheckedChanged(object sender, EventArgs e)
        {
        
        }

     
    

        // byte[] -> String 
        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;

        }
        // String -> byte[] 
        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }

      


        private void buttonDesign_Click(object sender, EventArgs e)
        {
            if (m_paper == null)
            {
                m_paper = new Paper();
            }
            int w, h;
            if (!int.TryParse(txtP_Width.Text, out w))
            {
                MessageBox.Show("라벨 사이즈(MM) Width 값을 확인해주세요.", "알림");
                return;
            }
            else if (!int.TryParse(txtP_Height.Text, out h))
            {
                MessageBox.Show("라벨 사이즈(MM) Height 값을 확인해주세요.", "알림");
                return;
            }
            m_paper.MM_SIZE = new Size(w, h);
            
            m_paper.orientation = radioButtonHorizontal.Checked == true ? 0 : 1;
            Visible = false;
            OpenDesignForm();
        }
        private void OpenDesignForm()
        {
            if (m_designForm == null)
            {
                m_designForm = new Form1();
                m_designForm.SetLabelFrom(this);
                m_designForm.Initalize(m_paper);
                m_designForm.Show();
            }
            else
            {
                m_designForm.Refresh(m_paper);
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
        
        }
     
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( m_designForm != null && !m_designForm.m_bQuit)
            {
                
                Visible = false;
                e.Cancel = true;
            }
        }

        private void buttonLoad_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filePath = dlg.FileName;
                using (var sr = new StreamReader(filePath))
                {
                    var data = sr.ReadToEnd();
                    try
                    {
                        m_paper = JsonConvert.DeserializeObject(data) as Paper;
                        OpenDesignForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("불러온 데이터 파일에 형식 오류가 있습니다.", "알림");
                    }
                }
            }
        }
    }
}
