using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMCSCRIPTINGLib;

namespace Sean_Library
{

    public static class MusicManager
    {
        //private DMCSCRIPTINGLib.Mp3Settings mp3;

        public static Boolean writeID3TagsToFile(ref Entities.AudioFile file)
        {
            try
            {
                DMCSCRIPTINGLib.Converter c = new Converter();
                c.WriteIDTag(file.fullFileName(), "Artist", file.ID3Tags().Artist);
                c.WriteIDTag(file.fullFileName(), "Title", file.ID3Tags().Title);
                LogManager.logMessage("ID3 tags for " + file.ToString() + " are created", System.Diagnostics.EventLogEntryType.Information);
                return true;
            }
            catch (Exception e)
            {
                LogManager.logMessage("Error whilst writing ID3 tags: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
                //throw;
            }
           
        }

        public static String exportID3ToXML(ref Entities.AudioFile file)
        {
            DMCSCRIPTINGLib.Converter c = new Converter();
            return "";
        }
    }
}
