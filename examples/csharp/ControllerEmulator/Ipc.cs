using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerEmulator
{
    internal class Ipc
    {
        static NamedPipeClientStream namedPipeClient;
        private string _pipeName = "YAOIDvr";
        private int _bufferSize = 1024;

        public string pipeName { get => _pipeName; }
        public int bufferSize { get => _bufferSize; }

        public Ipc(string name, int bufferSize = 1024)
        {
            this._pipeName = name;
            this._bufferSize = bufferSize;
            namedPipeClient = new NamedPipeClientStream(pipeName);
        }
        public bool Connect(bool fromSend = false)
        {
            namedPipeClient = new NamedPipeClientStream(pipeName);
            if (!fromSend) Debug.WriteLine($"Connecting to {pipeName}...");
            namedPipeClient.Connect();
            if (!fromSend) Send("bumpinthat", true);
            if (!fromSend) Debug.WriteLine("Connected!");
            if (!fromSend) Receive();
            return true;
        }

        void Reconnect()
        {
            namedPipeClient = new NamedPipeClientStream(pipeName);
            namedPipeClient.Connect();
        }

        public bool Send(string message, bool fromConnect = false)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(message);
            try
            {
                if (!fromConnect) this.Reconnect();
                namedPipeClient!.Write(bytes, 0, bytes.Length);
                Debug.WriteLine($"sent: {message}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public string Receive()
        {
            byte[] buffer = new byte[1024];
            int byteFromClient = namedPipeClient!.Read(buffer, 0, 1024);
            var str = System.Text.Encoding.Default.GetString(buffer);
            Debug.WriteLine($"received: {str}");
            //namedPipeClient.Close();
            return str;
        }

        public string SendRecv(string message)
        {
            Send(message);
            return Receive();
        }
    }
}
