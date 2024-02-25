using System;
using System.IO;

namespace IsogradC_02
{
    internal class Question
    {
        public void ShowFileContent(string filePath)
        {
            //-----------------------------------------------------------------

            if (File.Exists(filePath))
            {
                Console.WriteLine(File.ReadAllText(filePath));
            }

            //-----------------------------------------------------------------
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            (new Question()).ShowFileContent("text.txt");
        }
    }
}
