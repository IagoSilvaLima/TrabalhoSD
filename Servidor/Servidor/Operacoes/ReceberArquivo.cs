using Servidor.Interfaces;
using Servidor.Properties;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Servidor.Operacoes
{
    public class ReceberArquivo : IOperacao
    {
        
        public void Executar(byte[] dados, Socket socket,int tamanhoDados)
        {
            int tamNomeArquivo = BitConverter.ToInt32(dados, 4);
            string nomeArquivo = Encoding.UTF8.GetString(dados, 8, tamNomeArquivo);
            string caminho = Resources.Caminho + nomeArquivo;
            int metadados = 8 + nomeArquivo.Length;

            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(caminho, FileMode.Create, FileAccess.Write)))
            {
                binaryWriter.Write(dados, metadados, tamanhoDados - metadados);
                string mensagem = "Arquivo " + nomeArquivo + "recebido e gravado com sucesso";
                Console.WriteLine(mensagem);
                byte[] bMensagem = Encoding.UTF8.GetBytes(mensagem);
                socket.Send(bMensagem);
            }
                
        }
    }
}
