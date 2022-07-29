//using LabelEditor;
using LabelEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Config.Load();

            String printerName = "My printer name";
            //String query = String.Format("Select Name, PortName from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
       

            FormPrint p = new FormPrint();
            //   p.Test();
        }
            
       
    }
}
