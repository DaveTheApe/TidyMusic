using System;
using System.Collections.Generic;
using System.IO;

namespace TidyMusic
{
    class PathDiver
    {
        private List<PathDiver> subDiver;
        private List<string> folders;
        private List<string> mFiles;
        private static string[] vaildExt = new string[] { ".mp3" };
        private string dirName;
        public PathDiver(string path)
        {
            dirName = Path.GetDirectoryName(path);
            subDiver = new List<PathDiver>();
            foreach(string dir in Directory.GetDirectories(path))
            {
                subDiver.Add(new PathDiver(dir));
            }
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

        public List<PathDiver> GetSubDiver()
        {
            return subDiver;
        }

        public string GetDirName()
        {
            return dirName;
        }

        public Boolean SubDiverIsEmpty()
        {
            return subDiver.Count == 0;
        }

    }
}
