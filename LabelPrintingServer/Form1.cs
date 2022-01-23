using Newtonsoft.Json.Linq;
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
            FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            AsyncServer.Get().Close();
        }

        public void OnAddLog( object msg )
        {
            try
            {
                if (InvokeRequired)
                {
                    var func = new AddLog(OnAddLog);
                    Invoke(func, new object[] { msg });
                }
                else
                {
                    if (listBoxLog.Items.Count > 500)
                    {
                        listBoxLog.Items.Clear();
                    }
                    listBoxLog.Items.Insert(0, msg);
                }
            }
            catch(Exception ex)
            {
                TRACE.Log(ex.ToString());
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var keys = new List<string>();
            var values = new List<string>();
            keys.Add(textBoxKey0.Text);
            values.Add(textBoxValue0.Text);

            keys.Add(textBoxKey1.Text);
            values.Add(textBoxValue1.Text);

            keys.Add(textBoxKey2.Text);
            values.Add(textBoxValue2.Text);

            keys.Add(textBoxKey3.Text);
            values.Add(textBoxValue3.Text);

            keys.Add(textBoxKey4.Text);
            values.Add(textBoxValue4.Text);

            keys.Add(textBoxKey5.Text);
            values.Add(textBoxValue5.Text);

            keys.Add(textBoxKey6.Text);
            values.Add(textBoxValue6.Text);

            keys.Add(textBoxKey7.Text);
            values.Add(textBoxValue7.Text);

            keys.Add(textBoxKey8.Text);
            values.Add(textBoxValue8.Text);

            JObject j = new JObject();
            for ( int i = 0; i < 9; i++ )
            {
                if (!string.IsNullOrEmpty(keys[i]))
                {
                    j.Add(keys[i], values[i]);
                }
            }

            var json = j.ToString().Replace("\r\n", "");
            AsyncServer.Get().SendData(json);
            
        }
    }
}
