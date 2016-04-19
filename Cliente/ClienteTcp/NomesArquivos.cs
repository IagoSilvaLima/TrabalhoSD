using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTcp
{
    public class NomesArquivos : IOperacao
    {
        private ComboBox cArquivos;

        public NomesArquivos(ComboBox arquivos)
        {
            this.cArquivos = arquivos;
        }
        public void Executar(Socket socket, IPEndPoint server)
        {
            byte[] teste = new byte[1];
            socket.Connect(server);
            socket.Send(teste);

            byte[] bRecebido = new byte[1000];
            int tamRecebido = socket.Receive(bRecebido);
            string arquivos = Encoding.UTF8.GetString(bRecebido, 0, tamRecebido);
            string[] aArquivos = arquivos.Split(',');
            foreach (var s in aArquivos)
            {
                cArquivos.Items.Add(s);
            }
        }
    }
}
