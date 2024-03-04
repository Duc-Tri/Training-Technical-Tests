using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IsogradC_09
{
    public class Question
    {
        //---------------------------------------------------------------------

        object value;
        static WeakReference reference = null;

        public object GetValue()
        {
            if (reference == null || !reference.IsAlive)
            {
                value = CreateNewValue();
                reference = new WeakReference(value);
                Console.WriteLine("Garbage Collected (or weakreference is null)");
            }
            else
            {
                Console.WriteLine("same value");
            }
            return value;
        }
        //---------------------------------------------------------------------

        public object CreateNewValue()
        {
            // the code is hidden
            return new object();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                (new Question()).GetValue();
                if (i == 50)
                    GC.Collect();
            }
        }
    }
}
