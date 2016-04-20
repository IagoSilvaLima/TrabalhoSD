using Servidor.Interfaces;
using Servidor.Properties;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Servidor.Operacoes
{
    public class EnviarArquivo : IOperacao
    {
        public void Executar(byte[] dados, Socket socket, int tamanhoDados)
        {
            string nomeArquivo = Encoding.UTF8.GetString(dados, 4, tamanhoDados - 4);
            int nulo = nomeArquivo.IndexOf("\0");
            nomeArquivo = nomeArquivo.Substring(0, nulo);
            string caminho = Resources.Caminho + nomeArquivo;
            byte[] arquivo = File.ReadAllBytes(caminho);
            Console.WriteLine("Entregando arquivo " + caminho);
            socket.Send(arquivo);
            Console.WriteLine("Arquivo entregue");
        }
    }
}
