using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
   public class SocketServidor
   {
        private static int tamanhoNomeArquivo = 4;
        private static int NomeArquivo = 100;
        private static int tamanhoBuffer =1024*5 + tamanhoNomeArquivo + NomeArquivo;
        public static string mensagemCliente;
        public static string mensagemServidor;

        public static void Iniciar(int porta)
        {
            byte[] bytes = new byte[tamanhoBuffer];
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(ipAddress, porta);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(server);
                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Aguardando requisições");
                    Socket client = listener.Accept();
                    mensagemCliente = string.Empty;
                    int bytesRec = client.Receive(bytes);

                    int sizeNameFile = BitConverter.ToInt32(bytes, 0);
                    string fileName = Encoding.UTF8.GetString(bytes, 4, sizeNameFile);
                    string path = "C:\\Users\\Iago\\Documents\\"+fileName;
                    int metadados = 4 + fileName.Length;
                    BinaryWriter binaryWriter =new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write));
                    binaryWriter.Write(bytes, metadados ,bytesRec -metadados);
                    //mensagemCliente += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    //Console.WriteLine("Texto recebido:{0}", mensagemCliente);
                    Console.WriteLine(fileName + "recebido com sucesso");

                    byte[] msg = Encoding.ASCII.GetBytes(fileName + "recebido com sucesso"); ;
                    client.Send(msg);
                    binaryWriter.Close();
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       
   }
}
