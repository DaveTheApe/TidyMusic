using System;
using System.Collections.Generic;
using System.Text;

namespace TidyMusic
{
    class Directory
    {
        private string path;
        private List<Directory> subDirs;
        private List<File> files;
              
        public Directory(string p)
        {
            path = p;
            files = new List<File>();
            subDirs = new List<Directory>();
            foreach (string d in System.IO.Directory.GetDirectories(path))
            {
                subDirs.Add(new Directory(d));
            }
            foreach (string f in System.IO.Directory.GetFiles(path))
            {
                files.Add(new File(f));
            }
        }

        public string[] GetAllFiles()
        {
            var str = new List<string>();
            foreach (File f in files)
                str.Add(f.GetPath());
            return str.ToArray();
        }

        public List<Directory> GetSubDirs()
        {
            return subDirs;
        }

    }
}
