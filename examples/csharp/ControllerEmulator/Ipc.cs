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
        private NamedPipeClientStream namedPipeClient;
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
            if (!fromSend) Debug.WriteLine($"Connecting to {pipeName}...");
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
            if (pipeName == null) return false;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(message);
            try
            {
                namedPipeClient = new NamedPipeClientStream(pipeName);
                namedPipeClient.Connect();
                this.namedPipeClient.Write(bytes, 0, bytes.Length);
                namedPipeClient.WaitForPipeDrain();
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
            if (namedPipeClient == null) throw new Exception("Pipe Name not specified");
            byte[] buffer = new byte[1024];
            int byteFromClient = this.namedPipeClient.Read(buffer, 0, 1024);
            var str = System.Text.Encoding.Default.GetString(buffer);
            Debug.Write($"received {byteFromClient} bytes");
            Debug.WriteLine("");
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
