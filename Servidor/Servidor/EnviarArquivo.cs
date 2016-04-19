using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class EnviarArquivo : IOperacao
    {
        public void Executar(byte[] dados, Socket socket, int tamanhoDados)
        {
            string nomeArquivo = Encoding.UTF8.GetString(dados, 0, tamanhoDados);
            string caminho = "C:\\Users\\Iago\\Documents\\" + nomeArquivo;
            byte[] arquivo = File.ReadAllBytes(caminho);
            Console.WriteLine("Entregando arquivo " + caminho);
            socket.Send(arquivo);
            Console.WriteLine("Arquivo entregue");
        }
    }
}
