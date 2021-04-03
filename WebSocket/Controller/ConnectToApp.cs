using System;

namespace WebSocket.Controller
{
    public interface ConnectToApp
    {
        /// <summary>
        /// Implement this interface to define which app connect to server
        /// </summary>
        public void StartConnectToApp();
        
    }
}