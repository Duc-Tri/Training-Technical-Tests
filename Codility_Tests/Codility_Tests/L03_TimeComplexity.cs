using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
