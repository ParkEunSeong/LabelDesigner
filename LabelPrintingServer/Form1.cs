using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelPrintingServer
{
    public partial class Form1 : Form
    {
        public delegate void AddLog(object msg);
        public Form1()
        {
            InitializeComponent();
            Config.Load();
            TRACE.logHandle = OnAddLog;
            new Thread(() =>
            {
                AsyncServer.Get();
            }).Start();
            Text = "LabelPrintingServer Port["+Config.SERVER_PORT+"]";
        }
        public void OnAddLog( object msg )
        {
            if ( InvokeRequired )
            {
                var func = new AddLog(OnAddLog);
                Invoke(func, new object[] { msg });
            }else
            {
                if ( listBoxLog.Items.Count > 500 )
                {
                    listBoxLog.Items.Clear();
                }
                listBoxLog.Items.Insert(0, msg);
            }
        }
    }
}
