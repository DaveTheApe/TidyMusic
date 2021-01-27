using System;
using System.Text.RegularExpressions;
using System.IO;

namespace TidyMusic
{
    class Program
    {
            
        static void Main(string[] args)
        {
            String path = "";
            Logger.RotateLog();
            Logger.Out("TidyMusic helps you organize your music library folder-based.");
            do
            {
                Logger.Out("Music library path:");
                path = Path.GetFullPath(Console.ReadLine());
            } while (!System.IO.Directory.Exists(path));

            PathDiver pathDiver = new PathDiver(path,new string[]{ ".mp3", ".wav" });
            TrackManager trackManager = new TrackManager(pathDiver.GetValidFiles());
            FileManager fileManager = new FileManager(trackManager.GetPathMoveList(), path);
            fileManager.MoveFiles();

            Logger.Out("Done...");
            Logger.SaveLog();
            Console.ReadKey();
        }
        



        
    }
}
