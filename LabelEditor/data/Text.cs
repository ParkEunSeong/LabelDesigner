using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor.data
{
    public class Text
    {
        public Text()
        {

        }
        public Text( string key, bool fix )
        {
            this.key = key;
            this.Fix = fix;
        }
        public string key { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int font_size { get; set; }
        public string font_name { get; set; }
        public bool bold { get; set; }
        public int rotation { get; set; }
        public int datetime_type { get; set; }
        public int Id { get; set; }
        public bool Fix { get; set; }
        public bool Multile { get; set; }
        public string content { get; set; }
        public List<Text> m_multiple = new List<Text>();
        public static List<string> DataTimeFormat = new List<string>() { "", "yy-MM-dd HH:mm",
                                                                    "yyyy-MM-dd HH:mm",
                                                                      "yy년MM월dd일 HH시mm분",
                                                                      "yyyy년MM월dd일 HH시mm분"};
    }
}
