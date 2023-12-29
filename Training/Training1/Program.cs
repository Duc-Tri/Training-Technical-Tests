using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// PLAYLIST : 
// https://www.youtube.com/watch?v=-1NUQNSVVmk&list=PL6n9fhu94yhWlAv3hnHzOaMSeggILsZFs

namespace Training1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Part01();
            Part02();
            Part03();
            Part04();
            Part05();
            Part06();
            Part07();
            Part08();
            Part09();
            Part10();
            Part11();
            Part12();
        }

        // Can you store different types in a array ?
        static void Part01()
        {
            Console.WriteLine("===== PART01 : Can you store different types in a array ?");

            object[] array = new object[3];
            array[0] = 1;
            array[1] = "string1";
            array[2] = new DateTime();

            foreach (object o in array)
            {
                Console.WriteLine(o);
            }

            ArrayList arrayList = new ArrayList();
            arrayList.Add(2);
            arrayList.Add("string2");
            arrayList.Add(new DateTime());

            foreach (object o in arrayList)
            {
                Console.WriteLine(o);
            }
        }

        // What is jagged array ?
        static void Part02()
        {
            Console.WriteLine("===== PART02 : What is jagged array ?");

            string[][] jaggedArray = new string[3][];
            jaggedArray[0] = new string[3];
            jaggedArray[1] = new string[1];
            jaggedArray[2] = new string[2];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine($"len of array[{i}]: {jaggedArray[i].Length}");
            }
        }

        // Why and when shoud we use an abstract class ?
        static void Part03()
        {
            Console.WriteLine("===== PART03 : Why and when shoud we use an abstract class ?");
            Console.WriteLine("An abstract class prevents instantiation of objects of this class");
        }
        abstract class A
        {
            public abstract void AbstractMandatoryMethod();

            public virtual void VirtualMethodToOverride() { }
            public void NonVirtualNonOverridableMethod() { }
        }

        class B : A
        {
            public override void AbstractMandatoryMethod() { }
            public override void VirtualMethodToOverride() { }
        }

        // What are the advantages of using interfaces ?
        static void Part04()
        {
            Console.WriteLine("===== PART04 : What are the advantages of using interfaces ?");
            Console.WriteLine("1. interfaces allow us to develop loosely couple systems");
            Console.WriteLine("2. interfaces are very useful for dependency injection");
            Console.WriteLine("3. interfaces make unit testing and mocking easier");
        }

        // What is a recursive function ?
        static void Part05()
        {
            Console.WriteLine("===== PART05 : What is a recursive function ?");
        }

        // Recursive function real time example
        static void Part06()
        {
            Console.WriteLine("===== PART06 : Recursive function real time example");
            Console.WriteLine("Find all the files and sub-folders of a hierarchy.");

            void FindFiles(string path, int maxitems)
            {
                int items = 0;

                foreach (string filename in Directory.GetFiles(path))
                {
                    if (++items > maxitems) break;
                    Console.WriteLine(path + filename);
                }

                items = 0;
                foreach (string directory in Directory.GetDirectories(path))
                {
                    if (++items > maxitems) break;

                    FindFiles(directory, maxitems - 1); // NOT path + directory
                }
            }

            FindFiles("c:\\program files\\", 3);
        }

        // Is it possible to store n number of lists of different types in a single generic list ?
        static void Part07()
        {
            Console.WriteLine("===== PART07 : Is it possible to store n number of lists of different types in a single generic list ?");
            Console.WriteLine("Yes, by using List <List<object>>");
            List<List<object>> lists = new List<List<object>>();

        }

        // Can an abstract class have a constructor ?
        static void Part08()
        {
            Console.WriteLine("===== PART08 : Can an abstract class have a constructor ?");
            Console.WriteLine("Yes. That constructor will be called before constructor of derived class. Make it protected.");
        }

        // Can you call an abstract method from an abstract class constructor ?
        static void Part09()
        {
            Console.WriteLine("===== PART09 : Can you call an abstract method from an abstract class constructor ?");
            Console.WriteLine("Yes. When derived, the overrided method of derived class will be called.");
            BB b = new BB();
        }

        public abstract class AA
        {
            protected AA()
            {
                Print();
            }

            public abstract void Print();
        }

        public class BB : AA
        {
            public override void Print()
            {
                Console.WriteLine("BB derived from abstract AA ");
            }
        }

        // What happens if finally block throws an exception ?
        static void Part10()
        {
            Console.WriteLine("===== PART10 : What happens if finally block throws an exception ?");
            Console.WriteLine("The exception propagates up. If not handled, application crashes");
            Console.WriteLine("The finnaly block stops at the point where exception is throwsn");
            Console.WriteLine("If the finally block is being executed after an exception has occurred in the try block, AND if that exception is not handled, AND if the finally blocks throws an exception, the original excpetion of try block is lost");

            void FinallyThrowsException()
            {
                try
                {

                }
                finally
                {
                    int res = Convert.ToInt32("TEN");
                }
            }

            try
            {
                FinallyThrowsException();
            }
            catch
            {
                // silent catch
            }
        }

        // What is differnce between is and as keyword ?
        static void Part11()
        {
            Console.WriteLine("===== PART11 : What is differnce between is and as keyword ?");
            Console.WriteLine("- IS operator return true if an object can be cast to a specific object");
            Console.WriteLine("- AS operator attempts to cast an object to a specific type, and retur null if it fails");
            Console.WriteLine("- Cast operator throws exception if the conversion cannot be done");
        }

        // Difference between int and Int32
        static void Part12()
        {
            Console.WriteLine("===== PART12 : Difference between int and Int32 ?");
            Console.WriteLine("It's identical, but Int32 need using System.Int32, and cannot be used with enums");
        }

    }
}
