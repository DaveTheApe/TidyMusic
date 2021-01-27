using System;
using System.Collections.Generic;
using System.IO;

namespace TidyMusic
{
    class PathDiver
    {
        
        private Directory dir;
        private string[] validExt;
        private List<string> validFiles;


        public PathDiver(string p, string[] ext =null)
        {
            validFiles = new List<string>();
            if (ext == null)
                validExt = new string[] { ".mp3", ".wav" };
            dir = new Directory(p);
            validExt = ext;
            DiveDirectoryTree(dir);

        }

        private void DiveDirectoryTree(Directory subDir)
        {
            foreach(string f in subDir.GetAllFiles())
                if (FileIsVaild(f))
                    validFiles.Add(f);

            foreach(Directory d in subDir.GetSubDirs())
            {
                DiveDirectoryTree(d);
            }
        }

        public string[] GetValidFiles()
        {
            return validFiles.ToArray();
        }

        private Boolean FileIsVaild(string path)
        {
            foreach(string ext in validExt)
                if (ext.Equals(Path.GetExtension(path)))
                    return true;
            
            return false;
        }

    }
}
