using System;
using System.Threading.Tasks;

namespace ExempleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() => { HelloWorld(); });
            Console.WriteLine("Statut du task : {0}", task.Status);
            Console.WriteLine("Fin du main");

            task.Wait();
            Console.WriteLine("Statut du task : {0}", task.Status);
            Console.ReadLine();
        }

        private static void HelloWorld()
        {
            Console.WriteLine("Hello world depuis un Task");
        }
    }
}
