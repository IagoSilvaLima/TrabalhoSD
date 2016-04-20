using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTcp
{
    public interface IOperacao
    {
        Byte[] bytesEnviados();
        Byte[] bytesRecebidos();
        void AntesdaConexao();
        void DepoisdaConexao(int tamRecebido);
    }
}
