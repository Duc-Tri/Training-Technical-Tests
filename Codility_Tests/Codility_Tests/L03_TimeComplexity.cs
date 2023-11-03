using System;

namespace Codility_Tests
{
    public static class L03_TimeComplexity
    {
        // Count minimal number of jumps from position X to Y    
        public static int FrogJmp(int X, int Y, int D)
        {
            int interval = Y - X;
            int steps = interval / D;

            return (X + D * steps >= Y ? steps : steps + 1);
        }

        // Find the missing element in a given permutation.
        public static int PermMissingElem(int[] A)
        {
            int size = A.Length;
            if (size == 0) return 1;

            ulong realSum = 0;
            ulong sum = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                sum += (ulong)A[i];
                realSum += (ulong)i + 1;
            }
            realSum += (ulong)size + 1;

            //ulong realSum1 = (ulong)(size + 2) *(size + 1)/ 2; // overflow

            Console.WriteLine($" REALSUM:{realSum} SUM:{sum} diff:{realSum - sum}");

            return (int)(realSum - sum);
        }

        // Minimize the value |(A[0] + ... + A[P - 1]) - (A[P] + ... + A[N - 1])|.
        public static int TapeEquilibrium(int[] A)
        {
            int size = A.Length;
            long diff;
            long minDiff = long.MaxValue;

            long sumPart2;
            long totalSum = 0;
            for (int i = 0; i < size; i++) totalSum += (long)A[i];

            long sumPart1 = 0;
            for (int i = 0; i < size - 1; i++)
            {
                sumPart1 += (long)A[i];
                sumPart2 = totalSum - sumPart1;

                diff = (sumPart2 > sumPart1 ? sumPart2 - sumPart1 : sumPart1 - sumPart2);

                if (diff < minDiff)
                    minDiff = diff;
            }

            return (int)minDiff;
        }

    }

}
