using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

    public class Config
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                        int size, string filePath);

        
        public static int SERVER_PORT;
        public static void Load()
        {
            var filePath = Environment.CurrentDirectory + @"\config.ini";
            var builder = new StringBuilder();

            int value;


        
            GetPrivateProfileString("BASE", "SERVER_PORT", "0", builder, 128, filePath);
            int.TryParse(builder.ToString(), out value);
            SERVER_PORT = value;
        }

        static string configPath = Environment.CurrentDirectory + @"\config.ini";
        public static void Write(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, configPath);
        }

    }
