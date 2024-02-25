using System;

namespace IsogradC_01
{
    internal class Question
    {
        //---------------------------------------------------------------------

        public struct TypeByValue
        {
            public string Text { get; set; }
        }

        public class TypeByReference
        {
            public string Text { get; set; }
        }

        //---------------------------------------------------------------------
        public void MyMethod(TypeByValue valObj, TypeByReference refObj)
        {
            valObj.Text = "NewValue";
            refObj.Text = "NewValue";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var v = new Question.TypeByValue();
            var r = new Question.TypeByReference();

            (new Question()).MyMethod(v, r);
            Console.WriteLine("valObj.Text = " + v.Text);
            Console.WriteLine("refObj.Text = " + r.Text);
        }
    }
}


