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
        private static string[] vaildExt = new string[] { ".mp3", ".wav" };
        private string dirName;
        private string path;
        public PathDiver(string path)
        {
            dirName = Path.GetDirectoryName(path);
            this.path = path;
            subDiver = new List<PathDiver>();
            foreach(string dir in Directory.GetDirectories(path))
            {
                subDiver.Add(new PathDiver(dir));
            }
            mFiles = FilterMusicFiles();
        }

        private List<string> FilterMusicFiles()
        {
            List<string> musicFiles = new List<string>();
            foreach (string f in Directory.GetFiles(path))
            {
                if (FileIsVaild(f))
                {
                    musicFiles.Add(f);
                }
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
        public string GetPath()
        {
            return path;
        }

        public Boolean SubDiverIsEmpty()
        {
            return subDiver.Count == 0;
        }

        public Boolean FileIsVaild(string path)
        {
            foreach(string ext in vaildExt)
            {
                if (ext.Equals(Path.GetExtension(path)))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
