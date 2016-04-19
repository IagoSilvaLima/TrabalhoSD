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
        public static string mensagemServidor;

        public static void Iniciar(int porta)
        {
            byte[] bytes = new byte[tamanhoBuffer];
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(ipAddress, porta);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try { 
                listener.Bind(server);
                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Aguardando requisições");
                    Socket client = listener.Accept();
        
                    int bytesRec = client.Receive(bytes);

                    var operacao = FabricaOperacao.GetInstance(2);

                    operacao.Executar(bytes, client, bytesRec);
                    
                    
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
