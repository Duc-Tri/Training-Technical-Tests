using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsogradC_06
{
    public class Question
    {
        //---------------------------------------------------------------------
        public void InitializeFileCreationTracker(string pathToTrack)
        {

        }
        //---------------------------------------------------------------------

        public string NewFilePath { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            (new Question()).InitializeFileCreationTracker("test");
        }
    }
}
