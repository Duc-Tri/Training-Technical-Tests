using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            try
            {
                int a = 0;
                int b = 1;
                int c = b / a;

            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION générale");
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("EXCEPTION non nommée");
            }
            finally
            {
                Console.WriteLine("finally");
            }

            Console.WriteLine("fin MAIN ====================================");

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
        // public int n; // NOT ALLOWED
        public static int number;

        public string Name { get; set; }

        public void Method1();

        public void Method2()
        {
            Name = "IExample" + (number++);
        }

    }

    public static class StaticClass
    {

    }

    public static class StaticClass2
    {

    }

    public abstract class AbstractClass
    {
        protected abstract void MethodAbstract();

        private void Method1()
        {

        }
    }





}
