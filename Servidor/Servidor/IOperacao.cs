using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public interface IOperacao
    {
        void Executar(byte[] dados, Socket socket,int tamanhoDados);
    }
}
