using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using System.Reflection;

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

        public static int CountDiv(int A, int B, int K)
        {
            // If K is 1, then all numbers in the range are divisible by K
            if (K == 1)
            {
                return B - A + 1;
            }

            // Count the number of multiples of K in the range [A..B]
            int divisible = B / K - A / K;

            // If the first number in the range is divisible by K, add 1 to the count
            if (A % K == 0)
            {
                divisible++;
            }

            return divisible;
        }

        // Find the minimal nucleotide from a range of sequence DNA.
        public static int[] GenomicRangeQuery(string S, int[] P, int[] Q)
        {
            int N = S.Length;
            int M = P.Length;

            int[] impactFactorA = new int[N + 1];
            int[] impactFactorC = new int[N + 1];
            int[] impactFactorG = new int[N + 1];
            int[] impactFactorT = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                impactFactorA[i + 1] = impactFactorA[i] + (S[i] == 'A' ? 1 : 0);
                impactFactorC[i + 1] = impactFactorC[i] + (S[i] == 'C' ? 1 : 0);
                impactFactorG[i + 1] = impactFactorG[i] + (S[i] == 'G' ? 1 : 0);
                impactFactorT[i + 1] = impactFactorT[i] + (S[i] == 'T' ? 1 : 0);
            }

            int[] result = new int[M];

            for (int i = 0; i < M; i++)
            {
                int start = P[i];
                int end = Q[i] + 1;

                if (impactFactorA[end] - impactFactorA[start] > 0)
                {
                    result[i] = 1;
                }
                else if (impactFactorC[end] - impactFactorC[start] > 0)
                {
                    result[i] = 2;
                }
                else if (impactFactorG[end] - impactFactorG[start] > 0)
                {
                    result[i] = 3;
                }
                else
                {
                    result[i] = 4;
                }
            }
            return result;
        }



    }



}

