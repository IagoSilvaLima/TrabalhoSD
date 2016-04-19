using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class ListaArquivos : IOperacao
    {
        public void Executar(byte[] dados, Socket socket, int tamanhoDados)
        {
            string[] aArquivos = Directory.GetFiles("C:\\Users\\Iago\\Documents\\");

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
