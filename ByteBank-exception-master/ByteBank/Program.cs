using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(7485,5896);

            Console.WriteLine(ContaCorrente.TaxaOperacao);

            Console.ReadLine();
        }
    }
}
