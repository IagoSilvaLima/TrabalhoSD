using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class ReceberArquivo : IOperacao
    {
        
        public void Executar(byte[] dados, Socket socket,int tamanhoDados)
        {
            int tamNomeArquivo = BitConverter.ToInt32(dados, 0);
            string nomeArquivo = Encoding.UTF8.GetString(dados, 4, tamNomeArquivo);
            string caminho = "C:\\Users\\Iago\\Documents\\" + nomeArquivo;
            int metadados = 4 + nomeArquivo.Length;
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(caminho, FileMode.Create, FileAccess.Write));
            binaryWriter.Write(dados, metadados, tamanhoDados - metadados);
            string mensagem = "Arquivo " + nomeArquivo + "recebido e gravado com sucesso";
            Console.WriteLine(mensagem);
            byte[] bMensagem = Encoding.UTF8.GetBytes(mensagem);
            socket.Send(bMensagem);
            binaryWriter.Close();
        }
    }
}
