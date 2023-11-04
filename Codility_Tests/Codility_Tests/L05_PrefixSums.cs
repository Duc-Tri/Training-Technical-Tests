using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Codility_Tests
{
    public static class L05_PrefixSums
    {

        // Count the number of passing cars on the road
        public static int PassingCars1(int[] A)
        {
            int nbPairs = 0;
            int size = A.Length;

            int indexP = 0;
            for (indexP = 0; indexP < size; indexP++)
            {
                if (A[indexP] == 0) break;
            }

            do
            {
                int indexQ = indexP + 1;
                indexP = size;
                for (; indexQ < size; indexQ++)
                {
                    if (A[indexQ] == 1)
                    {
                        if (++nbPairs > 1_000_000_000) return -1;
                    }
                    else if (indexP == size) // next new P !
                        indexP = indexQ;
                }
            }
            while (indexP < size);

            return nbPairs;
        }

        public static int PassingCars(int[] A)
        {
            int eastCars = 0;
            int passingCars = 0;

            foreach (int car in A)
            {
                if (car == 0)
                {
                    eastCars++;
                }
                else if (car == 1)
                {
                    passingCars += eastCars;
                }

                if (passingCars > 1000000000)
                {
                    return -1;
                }
            }

            return passingCars;
        }

    }



}

