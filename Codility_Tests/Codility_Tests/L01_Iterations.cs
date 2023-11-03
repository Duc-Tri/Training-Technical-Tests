using System;

namespace Codility_Tests
{
    public static class L01_Iterations
    {
        // Find longest sequence of zeros in binary representation of an integer
        public static int BinaryGap(int N)
        {
            char[] binaryNumber = Convert.ToString(N, 2).ToCharArray();

            // Console.WriteLine(string.Join(" - ", binaryNumber));

            int gaps = 0;
            bool countingGap = false;
            int gapLen = 0;
            int maxGapLen = 0;

            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == '1')
                {
                    if (countingGap)
                    {
                        countingGap = false;
                        gaps++;
                        if (++gapLen > maxGapLen)
                            maxGapLen = gapLen;
                    }
                }
                else // 0
                {
                    if (!countingGap)
                    {
                        gapLen = 0;
                        countingGap = true;
                    }
                    else
                    {
                        gapLen++;
                    }
                }
            }

            return maxGapLen;
        }

    }

}
