using System;
using System.Collections.Generic;
using System.Text;

namespace TidyMusic
{
    class File
    {
        private string path;
        private string extension;
        private string name;

        public File(string p)
        {
            path = p;
            name = System.IO.Path.GetFileNameWithoutExtension(path);
            extension = System.IO.Path.GetExtension(path);
        }

        public string GetPath()
        {
            return path;
        }
    }
}
