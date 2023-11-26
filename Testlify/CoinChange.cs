
using System.Collections.Generic;
using System.Data.Common;

namespace StarChainGazerTest
{
    public class CoinChange
    {
        public static void CoinChanger(string arg)
        {
            if (string.IsNullOrEmpty(arg)) return;

            // code goes here  
            string[] args = arg.Split('-');

            //int nCoins = int.Parse(args[0]);

            int[] coins = args[0].Split(' ').Select(x => int.Parse(x)).ToArray();

            int sum = int.Parse(args[1]);

            Console.WriteLine(" {0}/ {1}/ {2}", coins.Length, string.Join("#", coins), sum);
            Console.WriteLine(" recursive WAYS ■■■■■■■■■■■■■■■■■■■■ {0}", countWays(coins, sum));
            Console.WriteLine(" iterative WAYS ■■■■■■■■■■■■■■■■■■■■ {0}", interativeDynamicProgramming(coins, sum));

        }

        static int countWays(int[] coins, int sum)
        {
            allUniqueWays.Clear();
            recursCountWays(new List<int>(), coins, 0, sum);

            return allUniqueWays.Count;
        }

        static List<string> allUniqueWays = new List<string>();
        private static void recursCountWays(List<int> way, int[] listInts, int currentSum, int finalSum)
        {
            if (currentSum > finalSum)
            {
                ////Console.WriteLine("■■■■■ TO MUCH !{0}", currentSum);
                return;
            }

            if (currentSum == finalSum)
            {
                string oneWay = string.Join(" / ", way);
                Console.WriteLine("====== FOUND A WAY : {0}", oneWay);

                if (!allUniqueWays.Contains(oneWay))
                    allUniqueWays.Add(oneWay);

                return;
            }

            if (currentSum < finalSum)
            {
                for (int i = 0; i < listInts.Length; i++)
                {
                    int v = listInts[i];

                    //List<int> newInts = new List<int>(ints);    
                    //newInts.RemoveAt(i);
                    way.Add(v);
                    way.Sort();

                    ////Console.WriteLine("=====use {0} (from  {1} to {2})", v, currentSum, finalSum);

                    recursCountWays(way, listInts, currentSum + v, finalSum);
                    way.Remove(v);
                }
            }
        }

        private static int interativeDynamicProgramming(int[] coinValues, int totalSum)
        {
            /*
            The final outcome will be calculated by the values in the last column and row.
            In this case, you must loop through all of the indexes in the memo table(except the first row and column) and use previously - stored solutions to the subproblems.

            If the coin value is greater than the dynamicprogSum, the coin is ignored, i.e.solutions[i][j] = solutions[i - 1][j].

            If the coin value is less than the dynamicprogSum, you can consider it, i.e.solutions[i][j] = solutions[i - 1].[dynamicprogSum] + solutions[i][j - coins[i - 1]].
            */

            for (int i = 0; i < coinValues.Length; i++)
                Console.Write($"CI:{i}►CV:{coinValues[i]} / ");
            Console.WriteLine($" TOTAL SUM={totalSum}");

            int[,] solutions = new int[totalSum + 1, coinValues.Length + 1];

            for (int coinIndex = 0; coinIndex < solutions.GetLength(1); coinIndex++)
            {
                //Console.Write($"{coinIndex} ■ ");

                for (int sum = 0; sum < solutions.GetLength(0); sum++)
                {
                    if (coinIndex == 0)
                        solutions[sum, coinIndex] = 0;
                    else
                    {
                        if (sum == 0)
                            solutions[sum, coinIndex] = 1;
                        else
                        {
                            Console.WriteLine($"==================== sum={sum} coinIndex={coinIndex}");

                            int coinValue = coinValues[coinIndex - 1];

                            Console.WriteLine($"solutions[S:{sum}, CI:{coinIndex}] = ►►► ");

                            if (coinValue > sum)
                            {
                                Console.WriteLine($"  CV:{coinValue} > S:{sum} ----- ");

                                Console.WriteLine($"     solutions[S:{sum}, CI-1:{coinIndex - 1}] = {solutions[sum, coinIndex - 1]}");

                                solutions[sum, coinIndex] = solutions[sum, coinIndex - 1];
                            }
                            else
                            {
                                Console.WriteLine($"  CV:{coinValue} <= S:{sum} ■■■■■");

                                Console.WriteLine($"     solutions[S:{sum}, CI-1:{coinIndex - 1}] = {solutions[sum, coinIndex - 1]} +");

                                Console.Write($"     solutions[S-CV:{sum - coinValue}, CI:{coinIndex}] = {solutions[sum - coinValue, coinIndex]}");

                                solutions[sum, coinIndex] = solutions[sum, coinIndex - 1] +
                                                                                solutions[sum - coinValue, coinIndex];
                            }

                            Console.WriteLine($" ►►► {solutions[sum, coinIndex]} ");
                        }
                    }

                }

                //Console.WriteLine();
            }

            int nSolutions = solutions[solutions.GetLength(0) - 1, solutions.GetLength(1) - 1];
            Console.WriteLine($"interativeDynamicProgramming: solutions= {nSolutions}");

            return nSolutions;
        }

        /*
        public static async Task Main(string[] args)
        {
            var result = await new Func<Task>(async () => await Task.Delay(2000));
        }
        */

        static async Task Main2(string[] args)
        {
            // keep this function call here
            //Console.WriteLine(Program(Console.ReadLine()));
            //Console.WriteLine(Program("2 5-8")); // 1

            CoinChanger("1 2 3-4"); // 4



            //█████ ASYNCHRONOUS LAMBDA

            // Create and run an asynchronous lambda expression
            Func<Task> asyncLambda = async () =>
            {
                Console.WriteLine("Async lambda is starting...");
                await Task.Delay(2000); // Simulate an asynchronous operation (e.g., I/O or network call)
                Console.WriteLine("Async lambda is complete.");
            };

            // Run the asynchronous lambda
            await asyncLambda();

            var res = (async () => await Task.Delay(2000));

        }

        static void Main(string[] args)
        {
            // keep this function call here
            //Console.WriteLine(Program(Console.ReadLine()));
            //Console.WriteLine(Program("2 5-8")); // 1

            CoinChanger("2 5-8"); // 1

            CoinChanger("1 2 3-4"); // 4
        }

    }
}
