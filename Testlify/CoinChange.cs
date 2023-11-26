
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

        private static int interativeDynamicProgramming(int[] coins, int sum)
        {
            /*
            The final outcome will be calculated by the values in the last column and row.

            In this case, you must loop through all of the indexes in the memo table(except the first row and column) and use previously - stored solutions to the subproblems.

            If the coin value is greater than the dynamicprogSum, the coin is ignored, i.e.dynamicprogTable[i][j] = dynamicprogTable[i - 1][j].

            If the coin value is less than the dynamicprogSum, you can consider it, i.e.dynamicprogTable[i][j] = dynamicprogTable[i - 1].[dynamicprogSum] + dynamicprogTable[i][j - coins[i - 1]].
            */

            int[,] dynamicprogTable = new int[sum + 1, coins.Length + 1];

            for (int coinsRange = 0; coinsRange < dynamicprogTable.GetLength(1); coinsRange++)
            {
                //Console.Write($"{coinsRange} ■ ");

                for (int dynamicprogSum = 0; dynamicprogSum < dynamicprogTable.GetLength(0); dynamicprogSum++)
                {
                    if (coinsRange == 0)
                        dynamicprogTable[dynamicprogSum, coinsRange] = 0;
                    else
                    {
                        if (dynamicprogSum == 0)
                            dynamicprogTable[dynamicprogSum, coinsRange] = 1;
                        else
                        {
                            Console.WriteLine($"==================== dynamicprogSum={dynamicprogSum} coinsRange={coinsRange}");
                            
                            int coinValue = coins[coinsRange - 1];

                            Console.WriteLine($"dynamicprogTable[{dynamicprogSum}, {coinsRange}] = ►►► ");

                            if (coinValue > dynamicprogSum)
                            {
                                Console.WriteLine($"  {coinValue} > {dynamicprogSum} ----- coinValue > dynamicprogSum ");

                                Console.WriteLine($"     dynamicprogTable[{dynamicprogSum}, {coinsRange - 1}] = {dynamicprogTable[dynamicprogSum, coinsRange - 1]}");

                                dynamicprogTable[dynamicprogSum, coinsRange] = dynamicprogTable[dynamicprogSum, coinsRange - 1];
                            }
                            else
                            {
                                Console.WriteLine($"  {coinValue} <= {dynamicprogSum} ■■■■■ coinValue <= dynamicprogSum ");

                                Console.WriteLine($"     dynamicprogTable[{dynamicprogSum}, {coinsRange - 1}] = {dynamicprogTable[dynamicprogSum, coinsRange - 1]} +");

                                Console.Write($"     dynamicprogTable[{dynamicprogSum - coinValue}, {coinsRange}] = {dynamicprogTable[dynamicprogSum - coinValue, coinsRange]}");
                                Console.WriteLine($"   ( dynamicprogSum - coinValue = {dynamicprogSum - coinValue} )");

                                dynamicprogTable[dynamicprogSum, coinsRange] = dynamicprogTable[dynamicprogSum, coinsRange - 1] +
                                                                                dynamicprogTable[dynamicprogSum - coinValue, coinsRange];
                            }

                            Console.WriteLine($" ►►► {dynamicprogTable[dynamicprogSum, coinsRange]} ");
                        }
                    }

                }

                //Console.WriteLine();
            }

            int nSolutions = dynamicprogTable[dynamicprogTable.GetLength(0) - 1, dynamicprogTable.GetLength(1) - 1];
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
