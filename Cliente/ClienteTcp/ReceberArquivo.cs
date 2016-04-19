using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTcp
{
    public class ReceberArquivo : IOperacao
    {
        private string nomeArquivo; 

        public ReceberArquivo(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
        }

        public void Executar(Socket socket, IPEndPoint server)
        {
            byte[] bNomeArquivo = new byte[100];
            byte[] bArquivo = new byte[5000];
            bNomeArquivo = Encoding.UTF8.GetBytes(nomeArquivo);
            socket.Connect(server);
            
            socket.Send(bNomeArquivo,nomeArquivo.Length,SocketFlags.None);

            int tamRecebidos = socket.Receive(bArquivo);
            Console.WriteLine("Arquivo recebido");
            string caminho = "C:\\Users\\Iago\\Desktop\\" + nomeArquivo;
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(caminho, FileMode.Create, FileAccess.Write));
            binaryWriter.Write(bArquivo);
            Console.WriteLine("Arquivo gravado");
            binaryWriter.Close();
        }
    }
}
