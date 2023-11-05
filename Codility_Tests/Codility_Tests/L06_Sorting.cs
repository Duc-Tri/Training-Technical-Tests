using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Codility_Tests
{
    public class L06_Sorting
    {
        // Compute number of distinct values in an array
        public static int Distinct(int[] A)
        {
            HashSet<int> watched = new HashSet<int>();
            int value = 0;

            for (int i = A.Length - 1; i >= 0; i--)
            {
                value = A[i];
                if (watched.Contains(value))
                    continue;
                else
                    watched.Add(value);
            }

            return watched.Count;
        }

        // Maximize A[P] * A[Q]* A[R] for any triplet(P, Q, R).
        public static int MaxProductOfThree(int[] A)
        {
            if (A.Length == 3) return A[0] * A[1] * A[2];

            Array.Sort(A);

            int size = A.Length;
            int max1 = A[size - 1] * A[size - 2] * A[size - 3];
            int max2 = A[0] * A[size - 1] * A[size - 2];
            int max3 = A[0] * A[1] * A[size - 1];

            return Math.Max(max3, Math.Max(max1, max2));
        }

    }
}
