using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;


public class HTTPConnection
{
    private WebHeaderCollection m_header = new WebHeaderCollection();
    private string m_url;
    public NameValueCollection m_param = new NameValueCollection();
    public static void Init()
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
               | SecurityProtocolType.Tls11
               | SecurityProtocolType.Tls12
               | SecurityProtocolType.Ssl3;

    }
    public HTTPConnection(Builder builder)
    {

        m_url = builder.m_url;
        foreach (var it in builder.m_dicHeader)
        {
            m_header.Add(it.Key, it.Value);
        }
        m_param = builder.m_param;

    }

    public enum Method
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class Builder
    {
        public Dictionary<string, string> m_dicHeader = new Dictionary<string, string>();
        public string m_url;
        public string m_contentType;
        public Method m_method;
        public NameValueCollection m_param = new NameValueCollection();

        public Builder AddHeader(string key, string value)
        {

            if (!m_dicHeader.ContainsKey(key))
                m_dicHeader.Add(key, value);
            return this;
        }
        public Builder SetURL(string url)
        {
            m_url = url;
            //  TRACE.Log(url);
            return this;
        }
        public Builder SetMethod(Method method)
        {
            m_method = method;
            return this;
        }
        public Builder SetContentType(string contentType)
        {
            m_contentType = contentType;
            return this;
        }

        public Builder AddParameter(string key, string value)
        {
            m_param.Add(key, value);
            return this;
        }
        public Builder SetParams( NameValueCollection col )
        {
            m_param = col;
            return this;
        }

        public HTTPConnection Build()
        {
            var ret = new HTTPConnection(this);
            return ret;
        }
    }
    public string AUTH_KEY { get; set; }

    public bool GetFileDownload(string url, string fileName)
    {
        WebClient wc = new WebClient();
        try
        {


            wc.DownloadFile(new Uri(url), fileName);

            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
        finally
        {
            wc.Dispose();
        }
    }

    public string Get()
    {
        try
        {
            if (m_param.Count > 0)
            {
                m_url += "?";
                for (int i = 0; i < m_param.Count; i++)
                {
                    var key = m_param.GetKey(i);
                    var value = m_param.GetValues(key);
                    m_url += key + "=" + value + "&";
                }
                m_url = m_url.Substring(0, m_url.Length - 1);
            }

            // Application Information Request

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(m_url);
            request.Timeout = 3000;
            request.Headers = m_header;

            Stream objStream = request.GetResponse().GetResponseStream();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(objStream);
            string strResponse = reader.ReadToEnd();
            TRACE.Log($"[{m_url}]{strResponse}");
            reader.Dispose();

            objStream.Dispose();
            response.Dispose();


            return strResponse;
        }
        catch (Exception ex)
        {
            TRACE.Log(ex.ToString());
            return null;
        }

    }
    public string PostJson(string data)
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(m_url);
            request.Headers = m_header;
            request.Method = "POST";
            request.ContentType = "text/plain";



            request.ContentLength = Encoding.UTF8.GetBytes(data).Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(data);
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
            string responseFromServer = reader.ReadToEnd();
            responseFromServer = DecodeEncodedNonAsciiCharacters(responseFromServer);
            TRACE.Log(responseFromServer);
            response.Dispose();
            dataStream.Close();
            reader.Close();
            return responseFromServer;
        }
        catch (Exception ex)
        {
            TRACE.Log(ex.ToString());
        }
        return "";
    }
    public string Post()
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(m_url);
            request.Headers = m_header;
            request.Timeout = 1500;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var data = "";

            for ( int i = 0; i < m_param.Count; i++ )
            {
                var key = m_param.GetKey(i);
                var value = m_param.GetValues(key)[0];
                data += key + "=" + value + "&";
            }
            data = data.Substring(0, data.Length - 1);


            request.ContentLength = Encoding.ASCII.GetBytes(data).Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(data);
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream, Encoding.ASCII);
            string responseFromServer = reader.ReadToEnd();
            responseFromServer = DecodeEncodedNonAsciiCharacters(responseFromServer);
            TRACE.Log(responseFromServer);
            response.Dispose();
            dataStream.Close();
            reader.Close();
            return responseFromServer;
        }
        catch (Exception ex)
        {
            TRACE.Log(ex.ToString());
        }
        return "";
    }
     

    static string DecodeEncodedNonAsciiCharacters(string value)
    {
        return Regex.Replace(
            value,
            @"\\u(?<Value>[a-zA-Z0-9]{4})",
            m =>
            {
                return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
            });
    }
    static string EncodeNonAsciiCharacters(string value)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in value)
        {
            if (c > 127)
            {
                // This character is too big for ASCII
                string encodedValue = "\\u" + ((int)c).ToString("x4");
                sb.Append(encodedValue);
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    public byte[] streamToByteArray(Stream input)
    {
        MemoryStream ms = new MemoryStream();
        input.CopyTo(ms);
        return ms.ToArray();
    }
    
    public Tout Post<Tout>()
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(m_url);

            request.Method = "POST";
            request.ContentType = "application/json";
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(JsonConvert.SerializeObject(m_param));
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            TRACE.Log(responseFromServer);
            response.Dispose();
            dataStream.Close();
            reader.Close();

            return JsonConvert.DeserializeObject<Tout>(responseFromServer);
        }
        catch (Exception ex)
        {
            TRACE.Log(ex.ToString());
        }
        return default(Tout);
    }

    public string Result(Action<string> callback)
    {
        //   Get(m_header, m_url);

        return "";
    }

}



