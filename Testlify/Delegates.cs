using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarChainGazerTest
{

    public delegate int operation(int x, int y);

    public class Delegates
    {
        static int Mul(int a, int b)
        {
            return a * b - (a);
        }

        static void Main(string[] args)
        {
            operation obj = new operation(Delegates.Mul);
            Console.WriteLine(obj(23, 27));
        }
    }
}
