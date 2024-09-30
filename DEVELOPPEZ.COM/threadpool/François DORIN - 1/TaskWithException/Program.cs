using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskWithException
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(new Func<string>(HelloWorld));
            Console.WriteLine("Statut du task : {0}", task.Status);
            Console.WriteLine("Fin du main");

            Console.WriteLine("Statut du task : {0}", task.Status);

            try
            {
                Console.WriteLine(task.Result);
            }
            catch(AggregateException ex)
            {
                Console.WriteLine("EXCEPTION : " + ex.InnerExceptions.First().Message);
            }

            Console.ReadLine();
        }

        private static string HelloWorld()
        {
            throw new NotImplementedException("TO DO");
        }
    }
}
