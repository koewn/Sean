using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sean_Library.Entities
{
    public class SeanXML:XmlDocument
    {
        public SeanXML()
        {
            this.Load("SeanBaseXMLTemplate.xml");
        }

        public override string ToString()
        {
            return this.InnerXml.ToString();
        }

        public void loadAudioData(AudioFile myFile)
        {
            this.SelectSingleNode("/SeanBaseTemplate/track/artist").Value = myFile.ID3Tags().Artist;
            this.SelectSingleNode("/SeanBaseTemplate/track/title").Value = myFile.ID3Tags().Title;
        }
    }
}
