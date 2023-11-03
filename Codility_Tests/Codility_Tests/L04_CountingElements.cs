using System.Xml.Linq;

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

    }
}
