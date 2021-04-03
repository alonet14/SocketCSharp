using System;
using System.Net;
using System.Net.Sockets;

namespace WebSocket
{
    public class WebServer
    {
        private TcpListener listener;
        private int port = 8080;

        private static System.Threading.AutoResetEvent
            listenForNextRequest = new System.Threading.AutoResetEvent(false);

        private HttpListener httpListener;
        public string Prefix { get; set; }
        public void Start()
        {
            if (String.IsNullOrEmpty(Prefix))
            {
                throw new InvalidOperationException("S")
            }
        }

        protected WebServer()
        {
            
        }
        public void StartWebServer()
        {
            try
            {
                listener = new TcpListener(port);
                listener.Start();
                Console.WriteLine("Web Server is Running ...");
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}