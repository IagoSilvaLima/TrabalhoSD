using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTcp
{
    public partial class FDownload : Form
    {
        private SocketCliente socket;

        public FDownload()
        {
            InitializeComponent();
        }

        public FDownload(SocketCliente socket)
        {
            InitializeComponent();
            this.socket = socket;
            socket.StartClient(new NomesArquivos(comboBox1));
        }

        
    }
}
