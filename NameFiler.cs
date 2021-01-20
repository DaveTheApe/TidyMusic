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
        private Track track;
        private string path;
        public NameFiler(String path)
        {
            this.path = path;
            track = new Track(TagLib.File.Create(path));
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

        public void Rename()
        {
            if (track.IsValid())
            {
                Logger.Out(ToString());
                System.IO.File.Move(path, Path.GetDirectoryName(path)+@"\"+newFile);
            }
        }
    }
}
