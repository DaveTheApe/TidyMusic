using System;
using System.Collections.Generic;
using System.Text;

namespace TidyMusic
{
    class TrackManager
    {
        //Should return tuples (oldPath,newPath) for the FileManager
        private List<Track> tracks;

        public TrackManager(string[] files)
        {
            tracks = new List<Track>();
            foreach (string f in files)
                try
                {
                    tracks.Add(new Track(f));
                }catch(TagLib.CorruptFileException e)
                {

                }
        }

        public string[] RenameFilename()
        {
            var str = new List<string>();
            foreach (Track t in tracks)
                str.Add(SplitPath(t.GetPath(),t.NameToString(),1));
            return str.ToArray();
        }

        public (string,string)[] GetPathMoveList()
        {
            var str = new List<(string,string)>();
            foreach (Track t in tracks)
                //sollte nochmal überarbeitet werden
                if(t.IsValid())
                    str.Add((t.GetPath(),string.Concat(t.GetArtist(),@"\",t.GetAlbum(),@"\",t.NameToString(),System.IO.Path.GetExtension(t.GetPath()))));
            return str.ToArray();
        }

        public string[] RenameAlbum()
        {
            var str = new List<string>();
            foreach (Track t in tracks)
                str.Add(SplitPath(t.GetPath(), t.GetAlbum(), 2));
            return str.ToArray();
        }

        public string[] RenameBand()
        {
            var str = new List<string>();
            foreach (Track t in tracks)
                str.Add(SplitPath(t.GetPath(), t.GetArtist(), 3));
            return str.ToArray();
        }


        private string RenameFullPath(string p, string b, string a, string t)
        {
            var splitPath = p.Split(@"\");
            splitPath[splitPath.Length - 1] = t;
            splitPath[splitPath.Length - 2] = a;
            splitPath[splitPath.Length - 3] = b;
            return String.Join(@"\", splitPath);
        }

        private string SplitPath(string p, string str, int i)
        {
            var splitPath = p.Split(@"\");
            splitPath[splitPath.Length - i] = str;
            return String.Join(@"\", splitPath);
        }
    }
}
