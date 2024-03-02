using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsogradC_10
{
    public class Question
    {
        public string RemoveDuplicateWords(string value)
        {
            //-----------------------------------------------------------------
            //value = Regex.Replace(value, @"\;\,\.", string.Empty);

            char[] charSplit = { ' ', ',', ';', '.' };

            string[] split = value.Split(charSplit);

            List<string> uniques = new List<string>();

            int i0 = 0;
            int i1;
            for (i1 = 1; i1 < split.Length; i1++)
            {
                if (string.IsNullOrEmpty(split[i1]) || string.Compare(split[i0], split[i1], true) == 0)
                    continue;

                uniques.Add(split[i0]);
                i0 = i1;
            }
            uniques.Add(split[i0]);

            Console.WriteLine(string.Join("_", uniques));

            return string.Join(" ", uniques);

            //-----------------------------------------------------------------
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            (new Question()).RemoveDuplicateWords("One one; two, two Three three Four.");
        }
    }
}
