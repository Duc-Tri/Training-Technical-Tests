using System;
using System.Threading;

namespace HelloException
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(HelloWorld);
            Console.WriteLine("Fin du main");
            Console.ReadLine();
        }

        private static void HelloWorld(object data)
        {
            throw new NotImplementedException("Aie, j'ai oublié d'écrire ma tâche !");
        }
    }
}
