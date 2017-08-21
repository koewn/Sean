using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sean_Library;
using System.IO;

namespace Sean_Console
{
    class Program
    {
        private static FileManager m_FileManager = new FileManager(); 

        static void Main(string[] args)
        {
            List<System.IO.FileSystemWatcher> listOfWatches = new List<System.IO.FileSystemWatcher>();

            foreach (String s in Properties.Settings.Default.DirectoryToWatch.Split('|')){
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Properties.Settings.Default.DirectoryToWatch;
                watcher.Filter = "*.wav";
                //watcher.Changed += new FileSystemEventHandler(fileChanged);
                watcher.Created += new FileSystemEventHandler(fileCreated);
                watcher.EnableRaisingEvents = true;
                listOfWatches.Add(watcher);
                Console.WriteLine("*** fileWatcher added " + watcher.Path );
            }

            Console.WriteLine("Nbr of watchfolders : " + listOfWatches.Count.ToString());
            Console.WriteLine("Waiting for file creations/changes...");
            Console.ReadLine();
        }

        private static void fileChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("--- FileChanged ---");
        }
        private static void fileCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("--- FileCreated --- " + e.FullPath);
            Sean_Library.Entities.AudioFile myFile = m_FileManager.createAudioFile(e.FullPath);
            if(Sean_Library.MusicManager.writeID3TagsToFile(ref myFile))
            { 
                Console.WriteLine("--- ID3Tags written to file --- ");
            }


        }
    }
}
