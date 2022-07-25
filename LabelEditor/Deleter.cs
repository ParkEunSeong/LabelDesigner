using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor
{
    public class Deleter
    {
        public static void DeleteTrace()
        {
            var path = @"trace";
            if (Directory.Exists(path))
            {
                var dir = new DirectoryInfo(path);
                var dirs = dir.GetDirectories();
                var curDay = DateTime.Now.AddDays(-180).ToString("yyyy-MM-dd");
                var fileName = "";
                foreach (var it in dirs)
                {
                    try {
                      
                        var tmp = it.Name;
                        var split = tmp.Split('_');

                        if (split != null && split.Length > 1)
                            tmp = split[1];
                        split = tmp.Split('-');
                        string compare = "";
                        foreach (var jt in split)
                        {
                            compare += jt;
                        }
                        int nCompare = 0;
                        int.TryParse(compare, out nCompare);
                        int nCurDay = 0;
                        int.TryParse(curDay, out nCurDay);
                        if (nCompare <= nCurDay - 90)
                        {
                            var delDir = new DirectoryInfo(it.FullName);
                            var files = delDir.GetFiles();
                            foreach (var kt in files)
                            {
                                try
                                {
                                    File.Delete(kt.FullName);
                                }
                                catch (Exception ex)
                                {
                                    TRACE.Log(ex.ToString());
                                }
                            }
                            fileName = it.FullName;
                            
                            Directory.Delete(it.FullName);
                        }
                    }
                    catch(Exception ex)
                    {
                        TRACE.Log($"{ fileName}, {ex.ToString()}");
                    }
               }
            }
        }
        public static void DeleteTraceLogger()
        {
            var path = @"node_tarce";
            if (Directory.Exists(path))
            {
                var dir = new DirectoryInfo(path);
              
                var curDay = DateTime.Now.AddDays(-30);
                var files = dir.GetFiles();
                var fileName = "";
                foreach (var kt in files)
                {
                    try
                    {
                        fileName = kt.Name;
                        var split = kt.Name.Split(' ');
                        if ( split != null && split.Length == 2 )
                        {
                            split = split[0].Split('-');

                            if (curDay > new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]) ))
                            {
                                File.Delete(kt.FullName);
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        TRACE.Log(fileName + ", " + ex.ToString());
                    }
                    
                   
                }
            }
        }
        public static void DeleteGmon()
        {
            var path = @"c:\greenATM\logs";
            if (Directory.Exists(path))
            {
                var dir = new DirectoryInfo(path);
                var curDay = DateTime.Now.AddDays(-30);
                var files = dir.GetFiles();
                var fileName = "";
                foreach (var kt in files)
                {
                    try
                    {
                        fileName = kt.Name;
                        
                        var split = kt.Name.Split(' ');
                        if (split != null && split.Length == 2)
                        {
                            split = split[0].Split('-');

                            if (curDay > new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])))
                            {
                                File.Delete(kt.FullName);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        TRACE.Log($"{fileName},{ex.ToString()}");
                    }
                   
                }
            }
        }
    }
}
