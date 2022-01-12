
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

    public class DeviceClient
    {
        public string m_code;
        public string m_os;
        public string m_model;
        public string m_manufacturer;
        public string m_internalStorage;
        public string m_externalStorage;
        public string m_ram;
        public string m_resolution;
        public string m_modelNo;
        public string m_imei;
        public string m_ordNum;
        public string m_phone;
        public string m_icloud;
        public string m_usim = "N";
        public string m_sdcard = "N";
        public string m_originData = "";
        public string m_batteryData = "";
        public int m_slotIdx;
        public string m_certPassId = "";
        public string m_mobile_co = "";

       
        public Socket m_socket;
        private Thread m_receiveThread;
        private bool m_bQuit;
        public Action<DeviceClient> OnClose;
        public Action OnCompletedDelete;
        public string m_pinCode;
        public Action<string> OnCheckICloud;
        public Action<string> OnReadySell;
        public Action<string> OnRecert;
        private int deletePercent;
     
        
        public DeviceClient( Socket socket )
        {
            m_socket = socket;
            m_socket.ReceiveTimeout = 2000;
            m_socket.SendTimeout = 2000;
            m_receiveThread = new Thread(() =>
            {
                //while (!m_bQuit)
                //{
                //    try
                //    {
                //        var byteArr = new byte[1024];
                //        int count = socket.Receive(byteArr);
                //        var rawData = new byte[count];
                //        Array.Copy(byteArr, rawData, count);
                //        var strData = Encoding.UTF8.GetString(rawData);
                //        if (strData != "")
                //        {
                //            TRACE.Log(strData);
                //            //  onAddLog?.Invoke(strData);
                //            try
                //            {
                //                JObject json = null;
                //                try
                //                {
                //                     json = JObject.Parse(strData);
                //                }
                //                catch(Exception ex)
                //                {
                //                    GREENATM.TRACE.Log("strData = " + strData + ", " + ex.ToString() );
                //                }
                //                if (json != null)
                //                {
                //                    var main = int.Parse(json["main"].ToString());
                //                    var sub = int.Parse(json["sub"].ToString());
                                    
                //                    if (main == 100 && sub == 0) // 핀코드 요청
                //                    {
                //                        ON_ACK_PIN_CODE(json, socket);
                //                    }
                //                    else if (main == 12 && sub == 0) // 배터리 응답
                //                    {
                //                        ON_ACK_BATTERY_INFO(json);
                //                    }
                //                    else if (main == 7 && sub == 1)
                //                    {
                //                        ON_ACK_FOREVER_RESET(json);
                //                    }
                //                    else if (main == 6 && sub == 0 )
                //                    {
                //                        var data = json["data"];
                //                        ON_ACK_IEMI(data["imei"].ToString());
                //                    }
                //                    else if (main == 6 && sub == 3)
                //                    {
                //                        ON_START_SELL(json, socket);
                //                    }
                //                    else if ( main == 6 && sub == 2 )
                //                    {
                //                        ON_RE_CERT(json);
                //                        //{ "main":6,"sub":2,"data":{ "hp":"01000000000","cert_pass_id":"1801873","mobile_co":"KTM"} }
                //                    }
                //                }
                //            }
                //            catch (Exception ex)
                //            {
                //                GREENATM.TRACE.Log(ex.ToString());
                //            }
                //        }
                //    }
                //    catch( Exception ex )
                //    {
                //        GREENATM.TRACE.Log(ex.ToString());
                //        Close();
                //    }
                //}
            });
          //  m_receiveThread.Start();
        }
 
        public void Close()
        {
            m_bQuit = true;
            if (m_receiveThread != null)
                m_receiveThread.Abort();
            if (m_socket != null && m_socket.Connected )
            {
                m_socket.Disconnect(false);
                m_socket.Dispose();
            }
            OnClose?.Invoke(this);

        }

        public void Send( byte[] arrData )
        {
            try
            {
                m_socket.Send(arrData);
            }
            catch(Exception ex)
            {
          
               TRACE.Log(ex.ToString());
            }
        }


    }
