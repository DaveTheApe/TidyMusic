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
            } while (!Directory.Exists(path));

            PathDiver pathDiver = new PathDiver(path);
            RenameFiles(pathDiver);

            Logger.Out("Done...");
            Logger.SaveLog();
            Console.ReadKey();
        }
        
        static void RenameFiles(PathDiver pathDiver)
        {
            foreach (string f in pathDiver.GetMusicFiles())
            {
                NameFiler nameFiler = new NameFiler(f);
                nameFiler.Rename();
            }

            if (pathDiver.SubDiverIsEmpty())
            {
                return;
            }

            foreach(PathDiver pd in pathDiver.GetSubDiver())
            {
                Logger.Out("Diving in: " + pd.GetPath());
                RenameFiles(pd);
            }
        }



        
    }
}
