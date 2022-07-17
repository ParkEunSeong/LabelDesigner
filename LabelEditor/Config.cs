using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
namespace AJKiosk
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
            var filePath = Environment.CurrentDirectory + @"\config.ini";
            var builder = new StringBuilder();

            int value;

            TRACE.Log("Config Path = " + filePath);
            GetPrivateProfileString("BASE", "FORM_TYPE", "2", builder, 128, filePath);
            FORM_TYPE = builder.ToString();
            GetPrivateProfileString("BASE", "SERVER_URL", "", builder, 128, filePath);
            SERVER_URL = builder.ToString();
            GetPrivateProfileString("BASE", "ARRAY_SEPARATOR", "", builder, 128, filePath);
            ARRAY_SEPARATOR = builder.ToString();
            GetPrivateProfileString("BASE", "PRINT", "", builder, 128, filePath);
            PRINT = builder.ToString();

        }

        static string configPath = Environment.CurrentDirectory + @"\config.ini";
        public static void Write(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, configPath);
        }

    }
}