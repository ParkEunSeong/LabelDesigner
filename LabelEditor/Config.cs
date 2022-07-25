using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
namespace LabelEditor
{
    public class Config
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                        int size, string filePath);

        public static string FORM_TYPE;
        public static string SERVER_URL;
        public static string ARRAY_SEPARATOR;
        public static string PRINT;


        public static void Load()
        {
            var filePath = Environment.CurrentDirectory + @"/config.ini";
            using (var sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("#"))
                    {
                        if (line.Contains("FORM_TYPE"))
                        {
                            var split = line.Split('=');
                            FORM_TYPE = split[1];
                            
                        }
                        else if (line.Contains("SERVER_URL"))
                        {
                            var split = line.Split('=');
                            SERVER_URL = split[1];
                        }
                        else if (line.Contains("ARRAY_SEPARATOR"))
                        {
                            var split = line.Split('=');
                            ARRAY_SEPARATOR = split[1];
                        }
                        else if (line.Contains("PRINT"))
                        {
                            var split = line.Split('=');
                            PRINT = split[1];
                        }
                    }
                }
                var text = sr.ReadToEnd();
                TRACE.Log("config = " + text);
            }
        }
     

        static string configPath = Environment.CurrentDirectory + @"\config.ini";
        public static void Write(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, configPath);
        }

    }
}