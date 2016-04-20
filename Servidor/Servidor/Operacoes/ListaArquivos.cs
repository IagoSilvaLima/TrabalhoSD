using Servidor.Interfaces;
using Servidor.Properties;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Servidor.Operacoes
{
    public class ListaArquivos : IOperacao
    {
        public void Executar(byte[] dados, Socket socket, int tamanhoDados)
        {
            string[] aArquivos = Directory.GetFiles(Resources.Caminho);

            for(var i = 0; i < aArquivos.Length; i++)
            {
                aArquivos[i] = Path.GetFileName(aArquivos[i]);
            }
            string  sArquivos = string.Join(",", aArquivos);
            
            byte[] bArquivos = Encoding.UTF8.GetBytes(sArquivos);
            socket.Send(bArquivos);
        }
    }
}
