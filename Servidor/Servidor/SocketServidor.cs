using Servidor.Fabrica;
using System;
using System.Net;
using System.Net.Sockets;

namespace Servidor
{
    public class SocketServidor
   {
        private static int tamanhoBuffer =1024 * 5000;
        

        public static void Iniciar(int porta)
        {
            byte[] bytes = new byte[tamanhoBuffer];
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(ipAddress, porta);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(server);
            listener.Listen(10);

            while (true)
            {
                Console.WriteLine("Aguardando requisições");

                using(Socket client = listener.Accept())
                {
                    int bytesRec = client.Receive(bytes);
                    int numOp = BitConverter.ToInt32(bytes, 0);
                    var operacao = FabricaOperacao.GetInstance(numOp);
                    operacao.Executar(bytes, client, bytesRec);
                    client.Shutdown(SocketShutdown.Both);
                }
                           
       
                }
            }
            
        }

       
   }

