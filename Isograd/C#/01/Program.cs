using System;

namespace IsogradC_01
{
    internal class IsogradC_01
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

        static void Main(string[] args)
        {
            TypeByValue v = new TypeByValue();
            TypeByReference r = new TypeByReference();

            (new IsogradC_01()).MyMethod(v, r);
            Console.WriteLine("valObj.Text = " + v.Text);
            Console.WriteLine("refObj.Text = " + r.Text);
        }
    }
}


