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
            return this.num + " " + this.artist + " - " + this.title;
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
