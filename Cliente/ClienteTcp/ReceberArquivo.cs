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
        private byte[] enviado;
        private byte[] recebido;

        public ReceberArquivo(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
        }


        public byte[] bytesEnviados()
        {
            if (enviado == null)
                enviado = new byte[100];
            return enviado;
        }

        public byte[] bytesRecebidos()
        {
            if (recebido == null)
                recebido = new byte[1024 * 5000];
            return recebido;
        }

        public void AntesdaConexao()
        {
            byte[] op = BitConverter.GetBytes(3);
            op.CopyTo(bytesEnviados(), 0);

            byte[] bNomeArquivo = new byte[100];
            bNomeArquivo = Encoding.UTF8.GetBytes(nomeArquivo);
            bNomeArquivo.CopyTo(bytesEnviados(), 4);
        }



        public void DepoisdaConexao(int tamRecebido)
        {
            Console.WriteLine("Arquivo recebido");
            string caminho = "C:\\Users\\Iago\\Documentos\\" + nomeArquivo;
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(caminho, FileMode.Create, FileAccess.Write)))
            {
                binaryWriter.Write(bytesRecebidos());
                Console.WriteLine("Arquivo gravado");
            }
        }
    }

}
