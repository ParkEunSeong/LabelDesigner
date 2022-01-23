
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
