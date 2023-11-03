using System.Reflection;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Threading.Tasks;

namespace Codility_Tests
{
    public static class L04_CountingElements
    {
        // Find the earliest time when a frog can jump to the other side of a river
        public static int FrogRiverOne(int X, int[] A)
        {
            int timeline = A.Length;
            int[] timeLeafFallen = new int[X]; // filled with zeros ???
            for (int i = 0; i < timeLeafFallen.Length; i++) timeLeafFallen[i] = int.MaxValue;

            int leafInPlace = 0;

            int numLeaf;
            for (int time = 0; time < timeline; time++)
            {
                numLeaf = A[time];
                if (numLeaf <= X)
                {
                    // new leaf in place !
                    if (timeLeafFallen[numLeaf - 1] == int.MaxValue)
                    {
                        timeLeafFallen[numLeaf - 1] = time;

                        leafInPlace++;
                    }
                    // memorize only best time
                    else if (time < timeLeafFallen[numLeaf - 1])
                        timeLeafFallen[numLeaf - 1] = time;

                    //System.Diagnostics.Debug.WriteLine($"----- time {time} ■ numLeaf {numLeaf} ■ leafInPlace {leafInPlace} ■  timeLeafFallen[{numLeaf - 1}] {timeLeafFallen[numLeaf - 1]}");
                }
            }

            //System.Diagnostics.Debug.WriteLine($"===== leafInPlace {leafInPlace} * X {X}");

            if (leafInPlace < X)
                return -1; // ERROR

            int completeTime = int.MinValue;
            for (int l = timeLeafFallen.Length - 1; l >= 0; l--)
            {
                if (timeLeafFallen[l] > completeTime)
                    completeTime = timeLeafFallen[l];
            }

            return completeTime;
        }

        // Check whether array A is a permutation.
        public static int PermCheck(int[] A)
        {
            int size = A.Length;
            bool[] check = new bool[size];
            ulong realSum = 0;
            ulong sum = 0;
            int value;
            for (int i = size - 1; i >= 0; i--)
            {
                value = A[i];

                // overflow
                if (value > size) return 0;

                // duplicate
                if (check[value - 1])
                    return 0;
                else
                    check[value - 1] = true;

                sum += (ulong)A[i];
                realSum += (ulong)i + 1;
            }

            return (sum == realSum ? 1 : 0);
        }

        // Calculate the values of counters after applying all alternating operations: increase counter by 1; set value of all counters to current maximum.
        public static int[] MaxCounters(int N, int[] A)
        {
            int[] counters = new int[N]; // filled with zeros
            int size = A.Length;

            int max = 0;
            int maxToApply = 0;

            for (int i = 0; i < size; i++)
            {
                int val = A[i];
                if (val <= N)
                {
                    if (counters[val - 1] < maxToApply) counters[val - 1] = maxToApply;

                    if (++counters[val - 1] > max) max = counters[val - 1];
                }
                else if (val == N + 1)
                {
                    maxToApply = max;
                }
            }

            for (int j = 0; j < N; j++)
                if (counters[j] < maxToApply) counters[j] = maxToApply;

            return counters;
        }

        // Find the smallest positive integer that does not occur in a given sequence.
        public static int MissingInteger(int[] A)
        {
            HashSet<int> subset = new HashSet<int>();
            int size = A.Length;
            int min = 1;
            int val;
            for (int i = 0; i < size; i++)
            {
                val = A[i];
                if (val <= 0) continue;

                if (min == val)
                {
                    do
                    {
                        subset.Remove(min);
                        min++;
                    }
                    while (subset.Contains(min));
                }
                else if (val > min && !subset.Contains(val))
                {
                    subset.Add(val);
                }
            }

            return min;
        }

    }
}
