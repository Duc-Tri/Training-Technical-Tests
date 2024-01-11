using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training4_C_features
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccessorsTest n0 = new AccessorsTest();
            //n0.number = 3;

        }

    }

    public class AccessorsTest
    {
        int number; // no accessor = private
        internal float floatNumber;

        public int MyProperty { get; set; }
        // public int MyProperty(int c) // IMPOSSIBLE

        public int Method1(int a)
        {
            return 0;
        }

        //public string Method1(int a) // NOT ALLOWED !
    }

    public class AccessorsTestDerived : AccessorsTest
    {
        AccessorsTestDerived()
        {
            //number = 0;
            floatNumber = 0;
        }
    }

    public interface IExample
    {
        public void MethodDeclaration();

        // from C# 8
        public void MethodImplementation()
        {
            Console.WriteLine("IExample::MethodImplementation");
        }

    }
}
