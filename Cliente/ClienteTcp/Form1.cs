using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTcp
{
    public partial class Form1 : Form
    {
        private SocketCliente socketClient;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(tbPort.Text);
            socketClient = new SocketCliente(port, tbAddress.Text);
            MessageBox.Show("Configurações Salvas com sucesso");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(socketClient == null)
            {
                MessageBox.Show("Configure o servidor");
                return;
            }

            if (string.IsNullOrEmpty(tbFile.Text))
            {
                MessageBox.Show("Escolha um arquivo");
                return;
            }

            socketClient.StartClient(tbFile.Text,lbLog);

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
