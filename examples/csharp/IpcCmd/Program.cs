using System.Diagnostics;
using System.IO.Pipes;

namespace IpcCmd
{
    internal class Program
    {
        static string? pipeName = "YAOIDvr";
        static NamedPipeClientStream? namedPipeClient;

        static void Main(string[] args)
        {
            Console.Write("Enter pipe name: << ");

            pipeName = Console.ReadLine();

            if (pipeName == null || pipeName.Length < 1) pipeName = "YAOIDvr";

            Reconnect(true);

            while (true)
            {
                Console.Write("<< ");
                string input = Console.ReadLine()!;
                if (input == ":q" || input == ":quit") Environment.Exit(0);
                else
                {
                    if (Send(input)) Console.WriteLine($">> {Receive()}");
                    else Console.WriteLine(":: command not sent");
                }
            }
        }

        static bool Send(string message)
        {
            if (pipeName == null) return false;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(message);
            try
            {
                namedPipeClient = new NamedPipeClientStream(pipeName);
                namedPipeClient.Connect();
                namedPipeClient.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        static string Receive()
        {
            if (namedPipeClient == null) throw new Exception("Pipe Name not specified");
            byte[] buffer = new byte[1024];
            int byteFromClient = namedPipeClient.Read(buffer, 0, 1024);
            var str = System.Text.Encoding.Default.GetString(buffer);
            namedPipeClient.Close();
            return str;
        }

        static void Reconnect(bool initial = false)
        {
            if (initial) Console.Write("Connecting... ");
            Send("bumpinthat");
            if (initial) { 
                Console.WriteLine(" ok! ");
                Console.WriteLine("\nSample commands to use:" +
                    "\n\tnumtrackers\treturns number of currently connected trackers and version" +
                    "\n\taddtracker [name] [role]\tadd new tracker" +
                    "\n\tgetdevicepose [id]\tgets positional data of device" +
                    "\n\tgettrackerpose [id]\tsame as above except for trackers" +
                    "\n\tupdatepose [id] [x] [y] [z] [qw] [qx] [qy] [qz] [delay]" +
                    "\nexit with :q or :quit\n\n");
            }
            Receive();
            return;
        }
    }
}
