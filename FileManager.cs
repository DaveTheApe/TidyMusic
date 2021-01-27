using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TidyMusic
{
    class FileManager
    {
        private (string,string)[] fileList;
        private string baseDir;
        public FileManager((string,string)[] files, string dir)
        {
            fileList = files;
            baseDir = dir + @"\";
        }

        public void MoveFiles()
        {
            foreach((string,string) pair in fileList)
            {
                var newPath = baseDir + pair.Item2;
                CreateFolders(newPath);
                try
                {
                    Logger.Out("Moving File: " + pair.Item1 + " -> " + newPath);
                    System.IO.File.Move(pair.Item1, newPath);
                }catch(System.IO.IOException e)
                {
                    Logger.Out("Error on File: " + pair.Item1 + " -> " + newPath + "Error: "+e.Message);
                }
            }
        }

        private void CreateFolders(string f)
        {
            var parentDir = GetParentDir(f, 1);
            Logger.Out("Creating Dir: " + parentDir);
            System.IO.Directory.CreateDirectory(parentDir);
        }

        public string GetParentDir(string path, int i)
        {
            List<string> parentPath=new List<string>(path.Split(@"\"));
            parentPath.RemoveRange(parentPath.Count - i, i);
            return String.Join(@"\",parentPath);
            
        }
    }
}
