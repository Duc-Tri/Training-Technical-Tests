using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        static  void Main(string[] args)
        {
            TaskWithoutReturn();
            
            Console.WriteLine("----------------");

            TaskWithReturn();
            
            Console.WriteLine("----------------");

            Console.WriteLine(  HelloWorldAsync().Result);

            Console.WriteLine("----------------");

            //Console.ReadLine();
        }

        private static async Task<string> HelloWorldAsync()
        {
            List<string> list = new List<string>();
            await Task.Delay(2000);
            list.Add("Hello");
            await Task.Delay(2000);
            list.Add("world");
            return String.Join(" ", list);
        }

        private static void TaskWithoutReturn()
        {
            Task task = Task.Run(() => { HelloWorld(); });
            Console.WriteLine("Statut du task : {0}", task.Status);

            task.Wait();
            Console.WriteLine("Statut du task : {0}", task.Status);
        }

        private static void HelloWorld()
        {
            Console.WriteLine(" --- Hello world depuis un Task");
        }

        private static void TaskWithReturn()
        {
            Task<string> task = Task.Run(new Func<string>(HelloWorld2));
            Console.WriteLine("Statut du task : {0}", task.Status);

            Console.WriteLine(task.Result);

            Console.WriteLine("Statut du task : {0}", task.Status);
        }

        private static string HelloWorld2()
        {
            return "Une chaîne d'autre Task...";
        }
    }
}
