using System.Collections.Generic;

class MainClass
{

    public static string Program(string arg)
    {
        if (string.IsNullOrEmpty(arg)) return arg;

        // code goes here  
        string[] args = arg.Split('-');

        //int nCoins = int.Parse(args[0]);

        List<int> coins = args[0].Split(' ').ToList().Select(x => int.Parse(x)).ToList();

        int sum = int.Parse(args[1]);

        Console.WriteLine(" {0}/ {1}/ {2}", coins.Count, string.Join("#", coins), sum);
        Console.WriteLine(" WAYS ■■■■■■■■■■■■■■■■■■■■ {0}", countWays(coins, sum));

        return arg;
    }

    static int countWays(List<int> coins, int sum)
    {
        allUniqueWays.Clear();
        recursCountWays(new List<int>(), coins, 0, sum);
        return allUniqueWays.Count;
    }

    static List<string> allUniqueWays = new List<string>();
    private static void recursCountWays(List<int> way, List<int> listInts, int currentSum, int finalSum)
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
            for (int i = 0; i < listInts.Count; i++)
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

    static void Main()
    {
        // keep this function call here
        //Console.WriteLine(Program(Console.ReadLine()));
        Console.WriteLine(Program("1 2 3-4")); // 4
        //Console.WriteLine(Program("2 5-8")); // 1
    }
}