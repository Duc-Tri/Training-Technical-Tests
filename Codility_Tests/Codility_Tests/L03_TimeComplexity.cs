using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

    }
}
