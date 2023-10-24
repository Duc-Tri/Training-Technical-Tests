using System.Collections.Generic;

class MainClass
{

    public static string Program(string arg)
    {
        if (string.IsNullOrEmpty(arg)) return arg;

        // code goes here  
        string[] args = arg.Split('-');

        int nCoins = int.Parse(args[0]);

        List<int> coins = args[1].Split(' ').ToList().Select(x => int.Parse(x)).ToList();

        int sum = int.Parse(args[2]);


        //coins.Sort(); // important !

        Console.WriteLine(" {0}/ {1}/ {2}", nCoins, string.Join("#", coins), sum);
        Console.WriteLine(" WAYS {0}", countWays(nCoins, coins, sum));

        return arg;
    }

    static int countWays(int n, List<int> coins, int sum)
    {
        allWays = 0;
        recursCountWays(coins.ToArray(), 0, sum);
        return allWays;
    }

    static int allWays;
    private static void recursCountWays(int[] ints, int currentSum, int finalSum)
    {
        if (currentSum > finalSum)
        {
            Console.WriteLine("-----TO MUCH !{0}", currentSum);
            return;
        }

        if (currentSum == finalSum)
        {
            Console.WriteLine("FOUND A WAY");
            allWays++;
            return;
        }

        if (currentSum < finalSum)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Console.WriteLine("=====use {0}", ints[i]);

                recursCountWays(ints, currentSum + ints[i], finalSum);
            }
        }
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(Program(Console.ReadLine()));
    }
}