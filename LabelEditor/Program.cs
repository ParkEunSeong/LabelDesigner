using AJKiosk;
using LabelEditor.data;
using Newtonsoft.Json;
using SampleProgram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.Load();
            TRACE.Log("프로그램 실행");
            TRACE.Log(Environment.CurrentDirectory);
            var text = "";
            if (args != null && args.Length > 0)
            {
                TRACE.Log(args[0]);
                var form = new FormPrint();
                form.OnFromServerData(args[0]);
                Application.Run(form);
            }
            else
            {
                var form = new frmMain();
                Application.Run(form);
            }

            //if ( Config.FORM_TYPE == "1" )
            //{
            //    var form = new TestDataForm();
            //    Application.Run(form);

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
