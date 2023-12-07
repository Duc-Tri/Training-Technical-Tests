using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace MPTronic_CodinGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ! " +(5/2));

            TestStructs();
            TestHashSet();
            TestLists();
            TestDictionary();
        }

        //=========================================================================================
        public static void TestDictionary()
        {
            var m = new Dictionary<object, int>();
            var o1 = new object();
            var o2 = o1;
            m[o1] = 1;
            m[o2] = 2;

            Console.WriteLine(m[o1]); // 2
        }

        //=========================================================================================
        public static void TestLists()
        {
            var list = new List<int>(2);
            list.Add(1);
            list.Add(1);
            list.Add(1);

            Console.WriteLine(list.Count); // 3
        }

        //=========================================================================================
        public static void TestHashSet()
        {
            var hashSet = new HashSet<int>();
            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(2);

            Console.WriteLine(hashSet.Count); // 2
        }

        //=========================================================================================
        struct Struct { public int foo; }
        public static void TestStructs()
        {
            Struct struct1;
            struct1.foo = 5;
            Struct struct2 = struct1;
            struct2.foo = 10;

            Console.WriteLine(struct1.foo); // 5
        }



        //=========================================================================================

        public static string Solve(int width, int height, int length, int mass)
        {
            bool heavy = mass >= 20; // 20 KG
            bool bulky = (width >= 150 || height >= 150 || length >= 150) || (width * height * length >= 1_000_000);

            if (heavy && bulky)
                return "REJECTED";
            else if (!heavy && !bulky)
                return "STANDARD";

            return "SPECIAL";
        }

        //=========================================================================================

        static int xMin = 0;
        static int yMin = 0;
        static int xMax = 10000;
        static int yMax = 10000;

        public static int[] Solve(string direction, int x, int y, int width, int height)
        {
            if (xMax >= width)
                xMax = width - 1;
            if (yMax >= height)
                yMax = height - 1;

            // dichotomie

            if (direction.Contains("R"))
            {
                if (x > xMin)
                    xMin = x;
                else
                    x = xMin;

                x = xMin + (xMax - xMin) / 2 + 1;
            }
            else if (direction.Contains("L"))
            {
                if (x < xMax)
                    xMax = x;
                else
                    x = xMax;

                x = xMin + (xMax - xMin) / 2;
            }

            if (direction.Contains("U"))
            {
                if (y < yMax)
                    yMax = y;
                else
                    y = yMax;

                y = yMin + (yMax - yMin) / 2;
            }
            else if (direction.Contains("D"))
            {
                if (y > yMin)
                    yMin = y;
                else
                    y = yMin;

                y = yMin + (yMax - yMin) / 2 + 1;
            }

            //Console.Error.Write(x+ " " + y);    
            return new int[] { x, y };
        }

        //=========================================================================================

        public static String Reshape(int n, String str)
        {
            String strNoSpace = string.Join("", str.Split(' '));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < strNoSpace.Length; i += n)
            {
                int len = Math.Min(n, strNoSpace.Length - i);
                sb.Append(strNoSpace.Substring(i, len) + "\n");
            }
            return sb.ToString();
        }

        //=========================================================================================

        public IEnumerable<string> Filter(List<string> strings)
        {
            return strings.Where(s => s.StartsWith("L")).OrderBy(s => s);
        }

        //=========================================================================================

        public static int FindLargest(List<int> numbers)
        {
            int largest = int.MinValue;

            foreach (int n in numbers)
                if (n > largest)
                    largest = n;

            return largest;
        }

        //=========================================================================================

        public class Answer
        {
            /// Executes the service with the given​​​​​​‌​‌​​‌‌‌‌‌​‌‌‌​​​​‌​​‌‌‌‌ connection.
            public void Run(Service s, Connection c)
            {
                s.SetConnection(c);
                try
                {
                    s.Execute();
                    c.Commit();
                }
                catch (Exception)
                {
                    c.Rollback();
                    throw;
                }
                finally
                {
                    c.Close();
                }
            }
        }

        /// Definition of a service
        public interface Service
        {
            void Execute();
            void SetConnection(Connection c);
        }

        /// Definition of a connection
        public interface Connection
        {
            void Commit();
            void Rollback();
            void Close();
        }

        //=========================================================================================

        public static int Solve(int weight0, int weight1, int weight2)
        {
            return (weight0 > weight1 ?
                (weight0 > weight2 ? 0 : 2) :
                (weight1 > weight2 ? 1 : 2));
        }

        //=========================================================================================

        public static int ComputeClosestToZero(int[] ts)
        {
            if (ts == null || ts.Length == 0)
                return 0;

            int nearestToZero = ts[0];

            for (int i = ts.Length - 1; i > 0; i--)
            {
                if (Math.Abs(ts[i]) < Math.Abs(nearestToZero))
                    nearestToZero = ts[i];
                else if (Math.Abs(ts[i]) == Math.Abs(nearestToZero) && ts[i] >= 0)
                    nearestToZero = ts[i];
            }

            return nearestToZero;
        }

        //=========================================================================================

        public static bool Exists(int[] ints, int k)
        {
            // ints est trié, par valeurs croissantes
            int indexA, indexB; // index début et fin de la section à examiner
            int indexMiddle, valueMiddle;

            indexA = 0;
            indexB = ints.Length - 1;

            while (indexB - indexA > 1)
            {
                indexMiddle = (indexB - indexA) / 2;
                valueMiddle = ints[indexA + indexMiddle];

                if (valueMiddle > k)
                    indexB = indexMiddle;
                else
                    indexA = indexMiddle;
            }

            for (int i = indexA; i <= indexB; i++)
            {
                if (ints[i] == k)
                    return true;
            }

            return false;
        }

    }

}
