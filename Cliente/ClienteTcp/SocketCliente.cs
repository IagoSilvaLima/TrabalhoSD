using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTcp
{
   public class SocketCliente
    {
        private const int SizeBuffer = 5 * 1024 +100 +4;
        public int Port { get; set; }
        public string Host { get; set; }
        public byte[] bytesSend { get; set; }

        public SocketCliente(int port,string host)
        {
            this.Port = port;
            this.Host = host;
            bytesSend = new byte[SizeBuffer];
        }


        public  void StartClient(string filePath,ListBox lbLog)
        {
            IPAddress ipAddress = IPAddress.Parse(Host);
            IPEndPoint serverRemote = new IPEndPoint(ipAddress,Port);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] fileByte = null;
                try {
                  
                fileByte = File.ReadAllBytes(filePath);
                    if(fileByte.Length > SizeBuffer)
                    {
                        lbLog.Text = "Tamanho do arquivo excedeu 5mb";
                        return;
                    }

                string fileName = Path.GetFileName(filePath);
                byte[] bytesReceive = new byte[SizeBuffer];
                byte[] nameLengthByte = BitConverter.GetBytes(fileName.Length);
                byte[] nameByte = Encoding.UTF8.GetBytes(fileName);

                nameLengthByte.CopyTo(bytesSend, 0);
                nameByte.CopyTo(bytesSend, 4);
                fileByte.CopyTo(bytesSend, 4 + fileByte.Length);
                

                sender.Connect(serverRemote);
                lbLog.Items.Add("Socket conectado com " + sender.RemoteEndPoint.ToString());
               // sender.Send(bytesSend);
                sender.Send(bytesSend, fileByte.Length + 4 + 100,SocketFlags.None);

                

                //int bytesSent = sender.Send(msg);

                int bytesRec = sender.Receive(bytesReceive);
                    lbLog.Items.Add("Texto recebido "+Encoding.ASCII.GetString(bytesReceive, 0, bytesRec));      
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
        }
    }
}
