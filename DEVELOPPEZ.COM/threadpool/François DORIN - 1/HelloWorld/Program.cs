using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HelloWorld
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
            Console.WriteLine("Hello World depuis une tâche");
        }
    }
}
