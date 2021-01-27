using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TidyMusic
{
    class FileManager
    {
        private string[] oldFiles;
        private string[] newFiles;
        public FileManager(string[] oldF, string[] newF)
        {
            oldFiles = oldF;
            newFiles = newF;
        }

        public void MoveFiles()
        {
            for(int i=0;i< newFiles.Length;i++)
            {
                System.IO.File.Move(oldFiles[i],newFiles[i]);
            }
        }

        public void CreateFolders()
        {
            string parentDir;
            foreach(string f in newFiles)
            {
                parentDir = GetParentDir(f, 1);
                Logger.Out("Creating Dir: " + parentDir);
                System.IO.Directory.CreateDirectory(parentDir);
            }
        }

        public string GetParentDir(string path, int i)
        {
            List<string> parentPath=new List<string>(path.Split(@"\"));
            parentPath.RemoveRange(parentPath.Count - i, i);
            return String.Join(@"\",parentPath);
            
        }
    }
}
