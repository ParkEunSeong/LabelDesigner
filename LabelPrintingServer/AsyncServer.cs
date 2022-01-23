using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class StateObject
{
    // Client  socket.  
    public DeviceClient workSocket = null;
    // Size of receive buffer.  
    public const int BufferSize = 1024;
    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];
    // Received data string.  
    public StringBuilder sb = new StringBuilder();
}
public class AsyncServer
{

    public static ManualResetEvent allDone = new ManualResetEvent(false);
    public List<DeviceClient> m_clientList = new List<DeviceClient>();
    public const int HEADER_SIZE = 24;
    private static AsyncServer m_instance;
    private static Thread m_receiveThread;
    private Socket m_listener;
    public Action OnDisconnect;
    public Action<DeviceClient> OnAddClient;
    public static string LAST_PINCODE = "";

    public static AsyncServer Get()
    {
        if (m_instance == null)
        {
            m_instance = new AsyncServer();
        }
        return m_instance;
    }
    public AsyncServer()
    {
        StartListening();
    }
    public DeviceClient GetClient(string pincode)
    {
        for (int i = 0; i < m_clientList.Count; i++)
        {
            if (m_clientList[i] != null && m_clientList[i].m_pinCode == pincode)
            {
                return m_clientList[i];
            }
        }
        return null;
    }
    public void Close()
    {
        try
        {
            if (m_listener != null)
            {
                // m_listener.Disconnect(false);
                m_listener.Close();
                m_listener = null;
            }
            if (m_receiveThread != null)
                m_receiveThread.Abort();
            for (int i = 0; i < m_clientList.Count; i++)
            {
                try
                {
                    m_clientList[i].m_socket.Disconnect(false);
                    m_clientList[i].m_socket.Dispose();
                }
                catch (Exception ex)
                {
                    TRACE.Log(ex.ToString());
                }
            }
            m_clientList.Clear();
        }
        catch (Exception ex)
        {
            TRACE.Log("앱서버종료 = " + ex.ToString());
        }

    }
    public void StartListening()
    {
        if (m_listener != null)
        {
            TRACE.Log("앱서버 실행되어있음");
            return;
        }
        // Establish the local endpoint for the socket.  
        // The DNS name of the computer  
        // running the listener is "host.contoso.com".  
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Config.SERVER_PORT);

        // Create a TCP/IP socket.  
        m_listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

        // Bind the socket to the local endpoint and listen for incoming connections.  
        try
        {
            m_listener.Bind(localEndPoint);
            m_listener.Listen(100);

            m_receiveThread = new Thread(() =>
            {
                while (true)
                {
                        // Set the event to nonsignaled state.  
                        allDone.Reset();

                        // Start an asynchronous socket to listen for connections.  
                        TRACE.Log("Waiting for a connection...");

                    m_listener.BeginAccept(
                            new AsyncCallback(AcceptCallback),
                            m_listener);


                        // Wait until a connection is made before continuing.  
                        allDone.WaitOne();
                }
            });
            m_receiveThread.Start();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void AcceptCallback(IAsyncResult ar)
    {
        try
        {
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = new DeviceClient(handler);
            TRACE.Log("라벨프린터 클라이언트 접속");
            m_clientList.Add(state.workSocket);
            OnAddClient?.Invoke(state.workSocket);
            state.workSocket.OnClose = delegate (DeviceClient deviceClient)
            {
                if (m_clientList.Contains(deviceClient))
                {
                    m_clientList.Remove(deviceClient);
                }
            };

            //MobileDeviceManager.CURRENT_DEVICE.m_socket = state.workSocket;

            //m_clientList.Add(state.workSocket);
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }
        catch (Exception ex)
        {
            TRACE.Log(ex.ToString());
        }
    }
    public void RemoveClient(string pincode)
    {
        for (int i = 0; i < m_clientList.Count; i++)
        {
            if (m_clientList[i] != null && m_clientList[i].m_pinCode == pincode)
            {
                m_clientList.RemoveAt(i);
                break;
            }
        }
    }
    public void DisconnectSocket(DeviceClient socket)
    {
        foreach (var it in m_clientList)
        {
            if (it.m_socket == socket.m_socket)
            {
                m_clientList.Remove(it);
                break;
            }
        }
    }

    public void ReadCallback(IAsyncResult ar)
    {
        try
        {
            String content = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket.m_socket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Clear();
                state.sb.Append(Encoding.UTF8.GetString(
                    state.buffer, 0, bytesRead));
                var strData = state.sb.ToString();
                if (strData != "")
                {

                    try
                    {
                        JObject json = null;
                        try
                        {
                            json = JObject.Parse(strData);
                            if (json != null)
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                            TRACE.Log(ex.ToString());

                        }

                        // Not all data received. Get more.  
                        Array.Clear(state.buffer, 0, 1024);
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);

                    }
                    catch (Exception ex)
                    {
                        TRACE.Log(ex.ToString());
                        state.workSocket.m_socket.Disconnect(false);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TRACE.Log(ex.ToString());
        }
    }
    public void SendData( string json )
    {
        foreach( var it in m_clientList )
        {
            if ( it.m_socket.Connected )
            {
                it.Send(Encoding.Default.GetBytes(json));
            }
        }
    }


}
