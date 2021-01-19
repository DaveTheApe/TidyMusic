using System;
using System.Collections.Generic;
using System.IO;

namespace TidyMusic
{
    class PathDiver
    {
        private List<string> folders;
        private List<string> mFiles;
        private static string[] vaildExt = new string[] { ".mp3" };
        public PathDiver(string path)
        {
            folders = new List<string>(Directory.GetDirectories(path));
            mFiles = FilterMusicFiles(path);
        }

        private List<string> FilterMusicFiles(string path)
        {
            List<string> musicFiles = new List<string>();
            foreach (string f in Directory.GetFiles(path))
            {
                musicFiles.Add(f);
            }
            return musicFiles;
        }

        public List<string> GetMusicFiles()
        {
            return this.mFiles;
        }
        public List<string> GetFolders()
        {
            return this.folders;
        }


    }
}
