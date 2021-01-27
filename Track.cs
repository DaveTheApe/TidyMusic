using System;
using System.Collections.Generic;
using System.Text;

namespace TidyMusic
{
    class Track
    {
        private string artist;
        private string title;
        private string album;
        private string num;
        private string path;
        
        public Track(string p)
        {
            path = p;
            var tFile = TagLib.File.Create(path);
            this.artist = tFile.Tag.FirstAlbumArtist;
            this.title = tFile.Tag.Title;
            this.album = tFile.Tag.Album;
            this.num = PrependZero(tFile.Tag.Track);
        }

        public string NameToString()
        {
            if (this.num.Equals("00"))
            {
                return this.artist + " - " + this.title;
            }
            return this.num + " " + this.artist + " - " + this.title;
        }

        public Boolean IsValid()
        {
            if(artist == null || title == null || album==null || num == null)
            {
                return false;
            }
            return true;
        }

        private string PrependZero(uint num)
        {
            if (num > 9)
            {
                return num.ToString();
            }
            else
            {
                return "0" + num.ToString();
            }
        }

        public string GetAlbum()
        {
            return album;
        }

        public string GetArtist()
        {
            return artist;
        }

        public string GetPath()
        {
            return path;
        }
    }
}
