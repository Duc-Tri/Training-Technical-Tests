using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAsync
{
    internal class Program
    {
        //=======================================
        // EXERCICE nombre premier
        //=======================================
        static bool HasADividerInInterval(int number, int dividerStart, int dividerEnd)
        {
            Console.WriteLine("HasADividerInInterval " + number + " dividerStart=" + dividerStart + " dividerEnd=" + dividerEnd);

            // dividerStart < dividerEnd
            if (number == 0) return false;
            if (dividerStart > dividerEnd) return false;

            if (number < dividerStart) return false;

            for (int divider = dividerStart; divider < dividerEnd; divider++)
            {
                if (number < divider) return false;

                if (number % divider == 0) return true;

                Thread.Sleep(1); // rallonge le temps de traitement artificiellement
            }

            return false;
        }

        static bool HasADividerInIntervalTaks(int number, int dividerStart, int dividerEnd)
        {
            int asyncNum = 20; // nombre de tasks

            int asyncInterval = (dividerEnd - dividerStart) / asyncNum; // intervalle entière

            List<Task<bool>> tasks = new List<Task<bool>>(); // liste de tasks

            Console.WriteLine(" ## HasADividerInIntervalTaks " + number + " asyncNum=" + asyncNum + " asyncInterval=" + asyncInterval);
            
            int divider = dividerStart;
            for (int i = 0; i < asyncNum; i++)
            {
                //Console.WriteLine(number + " ■■ " + divider + " / " + (divider + asyncInterval));

                int divStartTask = divider;
                int divEndTask = divider + asyncInterval;

                Task<bool> task = new Task<bool>(() => HasADividerInIntervalAsync(number, divStartTask, divEndTask));
                tasks.Add(task);

                divider += asyncInterval + 1;
            }

            foreach (var t in tasks)
                t.Start();

            int taskPos = Task.WaitAny(tasks.ToArray());

            return tasks[taskPos].Result;
        }

        public static bool HasADividerInIntervalAsync(int number, int dividerStart, int dividerEnd)
        {
            // dividerStart < dividerEnd

            if (dividerStart > dividerEnd) return false;

            Console.WriteLine("HasADividerInIntervalAsync " + number + " ■■ " + dividerStart + " -> " + dividerEnd);

            if (number < dividerStart) return false;

            for (int div = dividerStart; div <= dividerEnd; div++)
            {
                if (number <= div)
                    return false;

                if (number % div == 0)
                {
                    //Console.WriteLine("HasADividerInIntervalAsync ! " + number + " / " + div);
                    return true;
                }

                Thread.Sleep(1); // rallonge le temps de traitement artificiellement
            }

            return false;
        }

        private static void PrimeNumbers(int number)
        {
            //int prime = 1999; // 1999  =30967

            int primeNum = number; // 911 = 14034

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            bool res = HasADividerInIntervalTaks(primeNum, 2, primeNum - 1);
            Console.WriteLine("Prime ? " + primeNum + " ■■■ " + !res);
            stopwatch.Stop();
            Console.WriteLine("durée ■■■ " + stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Console.WriteLine("Prime ? --- " + !HasADividerInInterval(primeNum, 2, primeNum - 1));
            stopwatch.Stop();
            Console.WriteLine("durée --- " + stopwatch.ElapsedMilliseconds);
        }

        //=======================================
        // Intro
        //=======================================
        const int THREAD_COUNT = 10;

        private static void ExampleThreads()
        {
            Thread[] threads = new Thread[THREAD_COUNT];
            for (int i = 0; i < THREAD_COUNT; i++)
            {
                threads[i] = new Thread(Program.ConcurrencyAccessLock);
                threads[i].Start();
            }

            for (int i = 0; i < THREAD_COUNT; i++)
            {
                threads[i].Join();
            }
        }

        private static void Example1()
        {
            Console.WriteLine("Thread joined");
        }

        //=======================================
        // Mutex et lock
        //=======================================
        const int LOOP_COUNT = 10_000;

        private static Mutex mutex = new Mutex();


        private static int counter = 0;
        private static void ConcurrencyAccess()
        {
            for (int i = 0; i < LOOP_COUNT; i++)
            {
                mutex.WaitOne(); //////////////////
                counter++;
                mutex.ReleaseMutex(); ////////////////
            }
            Console.WriteLine("counter=" + counter);
        }

        private static object syncObject = new object();
        private static void ConcurrencyAccessLock()
        {
            for (int i = 0; i < LOOP_COUNT; i++)
            {
                lock (syncObject)
                {
                    counter++;
                }
            }
            Console.WriteLine("counter=" + counter);
        }

        //=======================================
        // Thread pool
        //=======================================
        private static void ThreadPoolExample()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(HelloWorld);
            }
            Console.WriteLine("enter pour quitter");
            Console.ReadLine();
        }

        private static void HelloWorld(object data)
        {
            Console.WriteLine("Do something");
        }

        //=======================================
        // Task
        //=======================================
        private static void TaskExample()
        {
            Task task = new Task(MyMethod);
            task.Start();
            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine("Main thread " + i);
            }
        }

        private static void MyMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Task MyMethod " + i);
            }
        }

        //=======================================
        // Task with lambda
        //=======================================
        private static void TaskLambdaExample()
        {

            Task task = new Task(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Task MyMethod " + i);
                }
            });

            task.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread " + i);
            }

            //Thread.Sleep(10);

            Console.WriteLine("End");
        }

        //=======================================
        // Wait for Task
        //=======================================
        private static void TaskWait()
        {
            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Task MyMethod " + i);
                }
            });

            task.Wait(); /////////////////////////

            Console.WriteLine("End");
        }

        //=======================================
        // Return value
        //=======================================

        private static void TaskReturnValue()
        {
            Task<double> task = Task.Run(() =>
            {
                Thread.Sleep(500);
                return new Random().NextDouble();
            });

            task.Wait();

            Console.WriteLine("Result " + task.Result);
        }

        //=======================================
        // WaitAny
        //=======================================
        static Random rand = new Random(); // non thread-safe
        static int Rand()
        {
            lock (rand)
            {
                return rand.Next(100, 2000);
            }
        }

        static void TaskWaitAny()
        {
            List<Task<int>> tasks = new List<Task<int>>
            {
                Task.Run(()=> { Thread.Sleep(Rand()); return 1; }),
                Task.Run(()=> { Thread.Sleep(Rand()); return 2; }),
                Task.Run(()=> { Thread.Sleep(Rand()); return 3; }),
                Task.Run(()=> { Thread.Sleep(Rand()); return 4; }),
            };

            while (tasks.Count > 0)
            {
                int pos = Task.WaitAny(tasks.ToArray());
                Console.WriteLine(tasks[pos].Result);
                tasks.Remove(tasks[pos]);
            }
        }

        //=======================================
        // Parallel For
        //=======================================
        private static void ParallelFor()
        {
            int accumulator = 0;
            String[] entries = { "Azerty", "Qwerty", "Tructy" };
            Parallel.For(0, entries.Length, i =>
            {
                foreach (char c in entries[i])
                {
                    Interlocked.Add(ref accumulator, c);
                }
            });

            Thread.Sleep(1000);

            Console.WriteLine("Accumulator=" + accumulator);
        }

        //#################################################################

        static void Main(string[] args)
        {
            //ExampleThreads();
            //ThreadPoolExample();
            //TaskExample();
            //TaskLambdaExample();
            //TaskWait();
            // TaskReturnValue();
            // TaskWaitAny();
            // ParallelFor();

            PrimeNumbers(911);

            // https://zestedesavoir.com/tutoriels/884/lasynchrone-et-le-multithread-en-net/

            // https://fdorin.developpez.com/tutoriels/csharp/threadpool/part1/

        }

    }

}
