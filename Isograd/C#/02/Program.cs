using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsogradC_02
{
    internal class Program
    {
        private void ShowFileContent(string filePath)
        {
            //-----------------------------------------------------------------

            if (File.Exists(filePath))
            {
                Console.WriteLine(File.ReadAllText(filePath));
            }

            //-----------------------------------------------------------------
        }

        static void Main(string[] args)
        {
            (new Program()).ShowFileContent("text.txt");
        }
    }
}
