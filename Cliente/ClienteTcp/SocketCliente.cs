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
        public int Port { get; set; }
        public string Host { get; set; }
        

        public SocketCliente(int port,string host)
        {
            this.Port = port;
            this.Host = host;
           
        }


        public  void StartClient(IOperacao operacao)
        {
            IPAddress ipAddress = IPAddress.Parse(Host);
            IPEndPoint serverRemote = new IPEndPoint(ipAddress,Port);
            using (var sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                operacao.AntesdaConexao();
                sender.Connect(serverRemote);
                sender.Send(operacao.bytesEnviados());
                int tamRecebidos = sender.Receive(operacao.bytesRecebidos());
                operacao.DepoisdaConexao(tamRecebidos);
            }
        }
    }
}
