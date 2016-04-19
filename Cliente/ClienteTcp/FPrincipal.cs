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
    public partial class FPrincipal : Form
    {
        private SocketCliente socket;

        public FPrincipal()
        {
            InitializeComponent();
            socket = null;
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var upload = new FUpload(socket);
            upload.ShowDialog();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var download = new FDownload(socket);
            download.ShowDialog();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(tbPort.Text);
            socket = new SocketCliente(port, tbAddress.Text);
        }
    }
}
