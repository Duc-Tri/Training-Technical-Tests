using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarChainGazerTest
{
    public class TaskActions
    {




        public static void Main(string[] args)
        {
            int[] array = new int[5];
            int len = array.Length;
            var action = new Action<int>((n) =>
            {
                for (int i = 0; i < n + len; i++)
                {
                    Task.Delay(5);
                    Console.WriteLine(i);
                }
            });


            Task myTask = new Task(() =>
            {
                action(5 / 2);

            });

            myTask.Start();
            myTask.Wait();
        }







    }
}
