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
        private bool m_bQuit;
        public NetClient( string ip, int port )
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_socket.Connect(ip, port);

            m_receiveThread = new Thread(() =>
           {
               while( ! m_bQuit )
               {
                   var byteArr = new byte[ushort.MaxValue];
                   var count = m_socket.Receive(byteArr);
                   var dataArr = new byte[count];
                   Array.Copy(byteArr, dataArr, count);
                   var strJson = Encoding.Default.GetString(dataArr);
                   TRACE.Log(strJson);
               }
           });
            m_receiveThread.Start();
        }
    }
}
