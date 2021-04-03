namespace WebSocket
{
    using System;
    using System.Text;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    
    public class MessageSocket
    {
        public static Socket EstapblishConnection(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            hostEntry = Dns.GetHostEntry(server);

            foreach (IPAddress address  in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                tempSocket.Connect(ipe);
                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }

            return s;
        }

        public static void StartServer()
        {
            
        }
        public static string SocketSendReceive(string server, int port)
        {
            string request = "Get / HTTP/1.1\r\nHost: " + server + "\r\nConnection: Close\r\n\r\n";
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];
            string page = "";

            using (Socket s = EstapblishConnection(server, port))
            {
                if (s == null)
                {
                    return "Connection failed";
                }

                s.Send(bytesSent, bytesSent.Length, 0);

                int bytes = 0;
                page = "Default HTML page on " + server + ":\r\n";

                do
                {
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
                } while (bytes > 0);
            }

            return page;
        }

        // public static void Main(string[] args)
        // {
        //     
        //     WebServer webServer = new WebServer();
        //     webServer.StartWebServer();
        //     
        //   
        // }
    }
}