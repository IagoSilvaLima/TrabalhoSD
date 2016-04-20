using Servidor.Interfaces;
using Servidor.Operacoes;

namespace Servidor.Fabrica
{
    public class FabricaOperacao
    {
        public static IOperacao GetInstance(int op)
        {
            if (op == 1)
                return new ReceberArquivo();
            if(op ==2)
                return new ListaArquivos();

            return new EnviarArquivo();
        }
    }
}
