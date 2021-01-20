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
        
        public Track(TagLib.File tfile)
        {
            this.artist = tfile.Tag.FirstAlbumArtist;
            this.title = tfile.Tag.Title;
            this.album = tfile.Tag.Album;
            this.num = PrependZero(tfile.Tag.Track);
        }

        public override string ToString()
        {
            if (this.num.Equals("00"))
            {
                return this.num + " " + this.artist + " - " + this.title;
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
            if (num.ToString().Length > 1)
            {
                return num.ToString();
            }
            else
            {
                return "0" + num.ToString();
            }
        }
    }
}
