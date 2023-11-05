using System.Collections.Generic;

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

    }
}
