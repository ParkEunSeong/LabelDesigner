using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabelEditor
{
    public class NetClient
    {
        public Socket m_socket;
        public Action onConnectFail;
        public Action onConnectSuccess;
        private Thread m_receiveThread;
        private Thread m_connectThread;
        public Action<string> onComeData;
        private bool m_bQuit;
        private string m_ip;
        private int m_port;
        private bool m_bConnect;
        public NetClient( string ip, int port )
        {
            m_ip = ip;
            m_port = port;
          
         

            
        }
      
        public void TryCnnnect()
        {
            new Thread(() =>
            {
                if (m_socket == null || (m_socket != null & !m_socket.Connected))
                {
                    m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        m_socket.Connect(m_ip, m_port);
                    }
                    catch (Exception ex)
                    {
                        TRACE.Log(ex.ToString());
                        return;
                    }
                    m_receiveThread = new Thread(() =>
                    {
                        try
                        {
                            while (!m_bQuit)
                            {


                                var byteArr = new byte[ushort.MaxValue];
                                var count = m_socket.Receive(byteArr);
                                var dataArr = new byte[count];
                                Array.Copy(byteArr, dataArr, count);
                                var strJson = Encoding.Default.GetString(dataArr);
                                TRACE.Log(strJson);
                                if (!string.IsNullOrEmpty(strJson))
                                {
                                    onComeData?.Invoke(strJson);

                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            TRACE.Log(ex.ToString());
                            m_socket = null;
                        }
                        TRACE.Log("쓰레드 빠져나옴");

                    });
                    m_receiveThread.Start();
                }
            }).Start();
        }

        public void Close()
        {
            m_bQuit = true;
            m_socket.Dispose();
            //m_socket.Shutdown(SocketShutdown.Both);
            m_receiveThread.Abort();
            m_receiveThread = null;
        }

        



    }
}
