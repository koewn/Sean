using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sean_Library.Entities
{
    public class ID3TagInfo
    {
        private String m_artist;
        private String m_title;

        public String Artist
        {
            get { return m_artist; }
            set { m_artist = value; }
        }

        public String Title
        {
            get { return m_title; }
            set { m_title = value; }
        }
        
        public override String ToString()
        {
            return "\nID3Tag info for track: " + m_title + " from artist " + m_artist;
        }
    }
}
