using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_Tests
{
    public static class IVALUATest
    {
        public static int LinkedList(int[] A)
        {
            int index = 0;
            int numElts; // elements de la liste

            for (numElts = 0; index != -1; numElts++)
            {
                index = A[index];
            }

            return numElts;
        }

        public static int WordMachine(string S)
        {
            Stack<int> stackInts = new Stack<int>();
            string[] operations = S.Split(' ');
            int MAX_NUMBER = (int)Math.Pow(2, 20) - 1;

            foreach (string operation in operations)
            {
                switch (operation)
                {
                    case "POP":
                        if (stackInts.Count == 0) return -1; // impossible to perform

                        stackInts.Pop();
                        break;

                    case "DUP":
                        if (stackInts.Count == 0) return -1; // impossible to perform

                        stackInts.Push(stackInts.Peek());
                        break;

                    case "+":
                        if (stackInts.Count < 2) return -1;

                        int sum = stackInts.Pop() + stackInts.Pop();
                        if (sum > MAX_NUMBER) return -1; // overflow

                        stackInts.Push(sum);
                        break;

                    case "-":
                        if (stackInts.Count < 2) return -1;

                        int diff = stackInts.Pop() - stackInts.Pop();
                        if (diff < 0) return -1; // undeflow


                        stackInts.Push(diff);
                        break;

                    default: // nombre par défaut, si pas une opé 
                        int number = int.Parse(operation);
                        if (number < 0 || number > MAX_NUMBER) return -1; // not valid number

                        stackInts.Push(number);
                        break;
                }
            }

            if (stackInts.Count == 0) return -1;

            return stackInts.Pop();
        }

    }
}
