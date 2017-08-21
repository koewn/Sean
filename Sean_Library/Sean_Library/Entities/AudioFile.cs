using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sean_Library.Entities
{
    public class AudioFile
    {

        private FileInfo m_file;
        private ID3TagInfo m_id3 = new ID3TagInfo(); 

        public AudioFile() { }
        public AudioFile(FileInfo f)
        {
            m_file = f;
            m_id3 = new ID3TagInfo();
            setID3Tags();
        }
        public AudioFile(FileInfo f, ID3TagInfo id3)
        {
            m_file = f;
            m_id3 = id3;
        }

        private void setID3Tags()
        {
            string[] stringSeparators = new string[] { " - " };
            List<String> result = new List<String>();

            result = m_file.Name.Split(stringSeparators, StringSplitOptions.None).ToList<String>();

            if (result.Count != 1)
            {
                m_id3.Artist = result[0].ToString();
                m_id3.Title = result[1].ToString();
            }
        }

        public override string ToString()
        {
            return m_file.FullName + " --ID3--> " + m_id3.ToString();
        }

        public string fullFileName()
        {
            return m_file.FullName;
        }

        public ID3TagInfo ID3Tags()
        {
            return m_id3;
        }
    }
}
