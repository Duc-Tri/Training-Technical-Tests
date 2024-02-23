using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsogradC_05
{
    public class Question
    {

        public class SingletonClass
        {
            private static SingletonClass _current;

            private SingletonClass()
            {
            }

            //-----------------------------------------------------------------
            public static readonly object padlock = new object();
            public static SingletonClass Current
            {
                get
                {
                    if (_current == null)
                    {
                        lock (padlock)
                        {
                            if (_current == null)
                                _current = new SingletonClass();
                        }
                    }
                    return _current;
                }
            }
            //-----------------------------------------------------------------
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
