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
            Console.WriteLine("TidyMusic helps you organize your music library folder-based.");
            do
            {
                Console.WriteLine("Music library path:");
                path = Path.GetFullPath(Console.ReadLine());
            } while (!Directory.Exists(path));

            PathDiver pathDiver = new PathDiver(path);
            foreach(string f in pathDiver.GetMusicFiles())
            {
                NameFiler nameFiler = new NameFiler(f);
                Console.WriteLine(nameFiler.ToString());
            }
            Console.ReadKey();
        }


        
    }
}
