using System;

namespace Sean_Library
{
    public class FileManager
    {
        public Entities.AudioFile createAudioFile(String path)
        {
            Entities.AudioFile myAudioFile = new Entities.AudioFile(new System.IO.FileInfo(path));
            return myAudioFile;
        }

        



    }

    public enum FileType
    {
        SeanXML = 1,
        DaletXML = 2  
    };
        
}

