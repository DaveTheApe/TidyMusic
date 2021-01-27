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


        public PathDiver(string p,string[] ext=[ ".mp3", ".wav" ])
        {
            dir = new Directory(p);
            validExt = ext;
            foreach (string f in dir.GetAllFiles())
                if (FileIsVaild(f))
                    validFiles.Add(f);

        }

        public string[] GetVaildFiles()
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
