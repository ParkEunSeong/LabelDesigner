using AJKiosk;
using greenATM.Util;
using LabelEditor.data;
using Newtonsoft.Json;
using SampleProgram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main( string[] args )
        {
#if DEBUG
                        //args = new string[1];
                        //using (var sr = new StreamReader("test.txt"))
                        //{
                        //    args[0] = sr.ReadToEnd();
                        //}
#endif
            Deleter.DeleteTrace();
            Deleter.DeleteTraceLogger();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.Load();
            TRACE.Log("프로그램 실행");
            TRACE.Log(Environment.CurrentDirectory);
            var text = "";
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            if (!Directory.Exists("data/spcm"))
                Directory.CreateDirectory("data/spcm");
            if (!Directory.Exists("data/brcl"))
                Directory.CreateDirectory("data/brcl");
            if (!Directory.Exists("data/card"))
                Directory.CreateDirectory("data/card");
            if (!Directory.Exists("data/etc"))
                Directory.CreateDirectory("data/etc");

            //if (false)
            //{
            if (args != null && args.Length > 0)
            {
                
                TRACE.Log(args[0]);
                var split = args[0].Split('^');
                byte[] orgBytes = Convert.FromBase64String(split[0]);
                string data = Encoding.Default.GetString(orgBytes);
                var form = new FormPrint();
                TRACE.Log("data= " + data );
                form.OnFromServerData(data, split[1]);
                //  Application.Run(form);
            }
            else
            {
                var form = new frmMain();
                Application.Run(form);
            }
            //}
            //if ( Config.FORM_TYPE == "1" )
            //{
            //    var form = new TestDataForm();
            //   Application.Run(form);

            //}
            //else if ( Config.FORM_TYPE == "2")
            //{

            //    var form = new FormPrint();
            //    form.OnFromServerData(args[0]);
            //    Application.Run(form);
            //}
            //else
            //{
            //    var form = new frmMain();
            //    Application.Run(form);
            //}

        }
    }
}
