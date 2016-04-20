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
        private byte[] enviado;
        private byte[] recebido;
        

        public NomesArquivos(ComboBox arquivos)
        {
            this.cArquivos = arquivos;
        }


        public void AntesdaConexao()
        {
            byte[] op = BitConverter.GetBytes(2);
            op.CopyTo(bytesEnviados(), 0);
        }

        public byte[] bytesEnviados()
        {
            if (enviado == null)
                enviado = new byte[4];
            return enviado; 
        }

        public byte[] bytesRecebidos()
        {
            if (recebido == null)
                recebido = new byte[200];
            return recebido;
        }

        public void DepoisdaConexao(int tamRecebido)
        {
            string arquivos = Encoding.UTF8.GetString(bytesRecebidos(), 0, tamRecebido);
            string[] aArquivos = arquivos.Split(',');
            foreach (var s in aArquivos)
            {
                cArquivos.Items.Add(s);
            }
        }

    }
}
