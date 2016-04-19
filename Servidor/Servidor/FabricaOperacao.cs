using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
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
