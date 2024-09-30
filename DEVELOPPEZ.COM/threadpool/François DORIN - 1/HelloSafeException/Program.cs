using System;
using System.Threading;

namespace HelloSafeException
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
            try
            {
                throw new NotImplementedException("Aie, j'ai oublié d'écrire ma tâche !");
            }
            catch
            {
                // Eventuellement, mettre un traitement qui permette de tracer l'exception,
                // ou de notifier le programme qu'un problème est survenu.
            }
        }
    }
}
