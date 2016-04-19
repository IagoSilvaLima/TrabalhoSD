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
    public class EnviaArquivo : IOperacao
    {
        private string caminhoArquivo;
        private byte[] bConteudo;

        public EnviaArquivo(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
            bConteudo = new byte[6000];
        }

        public void Executar(Socket socket,IPEndPoint server)
        {
            byte[] bArquivo = null;
            bArquivo = File.ReadAllBytes(caminhoArquivo);
            string nomeArquivo = Path.GetFileName(caminhoArquivo);
            byte[] bTamNomeAqr = BitConverter.GetBytes(nomeArquivo.Length);
            byte[] bNomeArq = Encoding.UTF8.GetBytes(nomeArquivo);
            int metadados = 4 + nomeArquivo.Length;
            bTamNomeAqr.CopyTo(bConteudo, 0);
            bNomeArq.CopyTo(bConteudo, 4);
            bArquivo.CopyTo(bConteudo, metadados);

            socket.Connect(server);
            socket.Send(bConteudo, bArquivo.Length + metadados, SocketFlags.None);

            byte[] bRecebido = new byte[300];
            int tamRecebido = socket.Receive(bRecebido);
            string sRecebido = Encoding.UTF8.GetString(bRecebido,0,tamRecebido);
            Console.WriteLine(sRecebido);
        }
    }
}
