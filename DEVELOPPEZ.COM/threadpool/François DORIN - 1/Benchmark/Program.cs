using System;
using System.Diagnostics;
using System.Threading;

namespace Benchmark
{
    /// <summary>
    /// Benchmark.
    /// 
    /// Ce programme permet de mettre en valeur le surcoût quant à l'utilisation
    /// de nouveaux threads au lieu de l'utilisation du pool de thread.
    /// 
    /// !! ATTENTION : Le résultat n'est qu'une estimation, et non un résultat précis !!
    /// 
    /// Pour gérer la synchronisation, j'ai utilisé des ManualResetEvent afin d'avoir un code
    /// qui soit le plus similaire possible entre les différentes approches à tester. Sans rentrer
    /// dans les détails, ces événements permettent de s'assurer que toutes les tâches demandées ont
    /// bien été effectuées avant de poursuivre.
    /// 
    /// Plus d'information sur l'utilisation des ManualResetEvent sur la MSDN :
    /// https://msdn.microsoft.com/fr-fr/library/system.threading.manualresetevent(v=vs.110).aspx
    /// </summary>
    class Program
    {        
        private const int THREAD_MAX = 10000; // Nombre d'itération pour le benchmark

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            ManualResetEvent[] handles = GetEvents();

            watch.Reset();
            watch.Start();
            UsingThreadPool(handles);
            watch.Stop();

            Console.WriteLine("ThreadPool : {0}", watch.ElapsedMilliseconds.ToString());

            watch.Reset();
            watch.Start();
            UsingThread(handles);
            watch.Stop();

            Console.WriteLine("Thread : {0}", watch.ElapsedMilliseconds.ToString());

            Console.ReadLine();
        }

        /// <summary>
        /// Lance une série de tâche en utilisant exclusivement 
        /// de nouveaux threads.
        /// </summary>
        /// <param name="handles">Evénements pour gérer la synchronisation</param>
        private static void UsingThread(ManualResetEvent[] handles)
        {
            Thread[] threads = new Thread[THREAD_MAX];

            for (int i = 0; i < THREAD_MAX; ++i)
            {
                Thread thread = new Thread(HeavyComputation);
                thread.Start(handles[i]);
                threads[i] = thread;
            }

            // Il n'est pas possible ici d'utiliser WaitHandle.WaitAll
            // car on ne peut attendre que 64 ManualResetEvent simultanément.
            for (int i = 0; i < THREAD_MAX; ++i)
            {
                handles[i].WaitOne();
            }
        }

        /// <summary>
        /// Lance une série de tâches en utilisant exclusivement
        /// le pool de threads.
        /// </summary>
        /// <param name="handles">Evénements pour gérer la synchronisation</param>
        private static void UsingThreadPool(ManualResetEvent[] handles)
        {
            for (int i = 0; i < THREAD_MAX; ++i)
            {
                ThreadPool.QueueUserWorkItem(HeavyComputation, handles[i]);
            }

            // Il n'est pas possible ici d'utiliser WaitHandle.WaitAll
            // car on ne peut attendre que 64 ManualResetEvent simultanément.
            for (int i = 0; i < THREAD_MAX; ++i)
            {
                handles[i].WaitOne();
            }
        }

        /// <summary>
        /// Cette méthode contient le code de la tâche à exécuter
        /// dans le cadre de notre benchmark.
        /// </summary>
        /// <param name="oResetEvent">Evénement permettant de gérer la synchronisation pour cette tâche</param>
        private static void HeavyComputation(object oResetEvent)
        {
            ManualResetEvent resetEvent = oResetEvent as ManualResetEvent;
            resetEvent.Set();
        }

        /// <summary>
        /// Allocation des différents événements pour gérer la synchronisation
        /// entre les tâches à effectuer et le thread principal.
        /// </summary>
        /// <returns>Tableau d'événements</returns>
        private static ManualResetEvent[] GetEvents()
        {
            ManualResetEvent[] handles = new ManualResetEvent[THREAD_MAX];
            for (int i = 0; i < handles.Length; ++i)
            {
                handles[i] = new ManualResetEvent(false);
            }

            return handles;
        }

        /// <summary>
        /// Réinitialise les événements en vue de pouvoir refaire un autre test.
        /// </summary>
        /// <param name="events">Le tableau d'événements à réinitialiser</param>
        private static void ClearEvents(ManualResetEvent[] events)
        {
            foreach (ManualResetEvent e in events)
            {
                e.Reset();
            }
        }

    }
}
