using IsogradC_06;
using System;
using System.IO;

namespace IsogradC_06
{
    public class Question
    {
        //---------------------------------------------------------------------
        public void InitializeFileCreationTracker(string pathToTrack)
        {
            using var watcher = new FileSystemWatcher(pathToTrack);

            watcher.NotifyFilter = NotifyFilters.FileName;

            watcher.Created += OnCreated;

            //watcher.Filter = "*.txt";
            //watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Watcher on !");
            Console.ReadLine();
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            NewFilePath = $"Created: {e.FullPath}";
            Console.WriteLine(NewFilePath);
        }
        //---------------------------------------------------------------------

        public string NewFilePath { get; set; }
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        Question q = new Question();
        q.InitializeFileCreationTracker(@"a:\www");
    }
}

