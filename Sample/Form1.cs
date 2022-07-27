//using LabelEditor;
using LabelEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            for (int i = 0; i < 20; i++)
            {
                FormPrint p = new FormPrint();
                p.Test(i);
            }
        }
    }
}
