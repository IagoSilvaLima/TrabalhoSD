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
        private byte[] enviado;
        private byte[] recebido;

        public EnviaArquivo(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public byte[] bytesEnviados()
        {
            if (enviado == null)
                enviado = new byte[1024 * 5000];
            return enviado;
        }

        public byte[] bytesRecebidos()
        {
            if (recebido == null)
                enviado = new byte[100];
            return enviado;
        }

        public void AntesdaConexao()
        {
            byte[] op = BitConverter.GetBytes(1);
            op.CopyTo(bytesEnviados(), 0);

            byte[] bArquivo = null;
            bArquivo = File.ReadAllBytes(caminhoArquivo);
            string nomeArquivo = Path.GetFileName(caminhoArquivo);
            byte[] bTamNomeAqr = BitConverter.GetBytes(nomeArquivo.Length);
            byte[] bNomeArq = Encoding.UTF8.GetBytes(nomeArquivo);
            int metadados = 8 + nomeArquivo.Length;

            bTamNomeAqr.CopyTo(bytesEnviados(), 4);
            bNomeArq.CopyTo(bytesEnviados(), 8);
            bArquivo.CopyTo(bytesEnviados(), metadados);
        }

        public void DepoisdaConexao(int tamRecebido)
        {
            string sRecebido = Encoding.UTF8.GetString(bytesRecebidos(), 0, tamRecebido);
            Console.WriteLine(sRecebido);
        }

        public void Executar(Socket socket,IPEndPoint server)
        {
            

            //socket.Connect(server);
            //socket.Send(bConteudo, bArquivo.Length + metadados, SocketFlags.None);

            //byte[] bRecebido = new byte[300];
            //int tamRecebido = socket.Receive(bRecebido);
            //string sRecebido = Encoding.UTF8.GetString(bRecebido,0,tamRecebido);
            //Console.WriteLine(sRecebido);
        }
        

        
    }
}
