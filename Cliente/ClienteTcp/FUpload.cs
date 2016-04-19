using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTcp
{
    public partial class FUpload : Form
    {
        private SocketCliente socket;
        

        public FUpload()
        {
            InitializeComponent();
        }

        public FUpload(SocketCliente socket)
        {
            InitializeComponent();
            this.socket = socket;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(tbFile.Text))
            {
                MessageBox.Show("Escolha um arquivo");
                return;
            }

            socket.StartClient(new EnviaArquivo(tbFile.Text));

        }

        private void btEscolher_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
