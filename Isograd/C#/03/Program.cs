using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsogradC_03
{
    public class Question
    {
        public void MyMethod(Action actionDelegate, out int value)
        {
            try
            {
                actionDelegate();
                value = 0;
            }
            catch
            {
                value = 0;
            }

            //-----------------------------------------------------------------

            //-----------------------------------------------------------------

        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            int val = 0;
            Action action = () => val = 0;
            (new Question()).MyMethod(action, val);
        }
    }
}
