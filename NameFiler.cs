using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TidyMusic
{
    class NameFiler
    {
        private string oldFile;
        private string newFile;
        public NameFiler(String path)
        {
            var track = new Track(TagLib.File.Create(path));
            string ext = Path.GetExtension(path);
            oldFile = Path.GetFileName(path);
            newFile = track.ToString() + ext;
            //Console.WriteLine("Renaming: "+oldFile+" -> "+newFile);
            //System.IO.File.Move(path, Path.GetDirectoryName(path)+@"\"+newFile);
        }

        public override string ToString()
        {
            return "Renaming: " + oldFile + " -> " + newFile;
        }
    }
}
