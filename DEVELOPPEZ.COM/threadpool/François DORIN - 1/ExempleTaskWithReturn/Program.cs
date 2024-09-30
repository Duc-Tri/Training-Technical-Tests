using System;
using System.Threading.Tasks;

namespace ExempleTaskWithReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(new Func<string>(HelloWorld));
            Console.WriteLine("Statut du task : {0}", task.Status);
            Console.WriteLine("Fin du main");

            Console.WriteLine("Statut du task : {0}", task.Status);
            Console.WriteLine(task.Result);
            Console.ReadLine();
        }

        private static string HelloWorld()
        {
            return "Une chaîne d'autre Task...";
        }
    }
}
