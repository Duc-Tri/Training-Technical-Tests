using System;

namespace IsogradC_01
{
    internal class IsogradC_01
    {
        //---------------------------------------------------------------------

        public struct TypeByValue
        {
            public string text;
            public string Text
            {
                get { return text; }
                set { }
            }
        }

        public class TypeByReference
        {
            public string Text { get; set; }
        }

        //---------------------------------------------------------------------
        public void MyMethod(TypeByValue valObj, TypeByReference refObj)
        {
            valObj.Text = "NewValue";
            Console.WriteLine("valObj.Text = " + valObj.Text);
            refObj.Text = "NewValue";
            Console.WriteLine("refObj.Text = " + refObj.Text);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IsogradC_01.TypeByReference r = new IsogradC_01.TypeByReference();

            (new IsogradC_01()).MyMethod(new IsogradC_01.TypeByValue(), r);
        }
    }
}


