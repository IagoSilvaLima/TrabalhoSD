using System.Net.Sockets;

namespace Servidor.Interfaces
{
    public interface IOperacao
    {
        void Executar(byte[] dados, Socket socket,int tamanhoDados);
    }
}
