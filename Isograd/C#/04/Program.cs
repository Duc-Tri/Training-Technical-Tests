using System;

namespace IsogradC_04
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}i", Real, (Imaginary < 0 ? "-" : "+"), Math.Abs(Imaginary));

        }

        //---------------------------------------------------------------------
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);

        //---------------------------------------------------------------------

        internal class Program
        {
            static void Main(string[] args)
            {
                Complex c1 = new Complex(1, 2);
                Complex c2 = new Complex(3, 4);
                Complex somme = c1 + c2;
                Console.WriteLine("Somme = " + somme);
            }
        }

    }

}
