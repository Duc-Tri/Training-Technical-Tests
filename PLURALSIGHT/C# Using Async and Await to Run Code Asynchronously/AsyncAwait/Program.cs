using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    /* In our Example.cs file, let’s create an asynchronous method Subtraction that will return an int value. The returned int value will be the results of the value from SlowMethodOneAsync subtracted by the value from SlowMethodTwoAsync. */
    public static partial class Example
    {
        /* First, add the async modifier to the method declaration as well as the appropriate return type (Reminder: Async methods have their own special return types) */

        public async static Task<int> Subtraction()
        {

            Task<int> taskOne = SlowMethodOneAsync();
            Task<int> taskTwo = SlowMethodTwoAsync();
            return await taskOne - await taskTwo;
        }

        /* Next, update the method to return the results of a call to SlowMethodTwoAsync subtracted from SlowMethodOneAsync. */
        private static async Task<int> SlowMethodTwoAsync()
        {
            return 4;
        }

        private static async Task<int> SlowMethodOneAsync()
        {
            return 5;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Subtraction " + Example.Subtraction().Result);
        }
    }
}
