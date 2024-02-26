using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsogradC_07
{
    public class Question
    {
        public void TestMethod()
        {
            Child childObject = new Child();
            Parent parentObject = childObject;
            Console.WriteLine(parentObject.GetValue1()); // must return "child_value_1"
            Console.WriteLine(parentObject.GetValue2()); // must return "parent_value_2"
            Console.WriteLine(childObject.GetValue1()); // must return "child_value_1"
            Console.WriteLine(childObject.GetValue2()); // must return "child_value_2"
        }

        public class Parent
        {
            public virtual string GetValue1()
            {
                return "child_value_1";
            }

            public virtual string GetValue2()
            {
                return "parent_value_2";
            }
        }

        public class Child : Parent
        {
            //---------------------------------------------------------------------
            public override string GetValue1()
            {
                return "child_value_1";
            }

            public new string GetValue2()
            {
                return "child_value_2";
            }
            //---------------------------------------------------------------------
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            (new Question()).TestMethod();
        }
    }
}
