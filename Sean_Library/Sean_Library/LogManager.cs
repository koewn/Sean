using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Sean_Library
{
    public class LogManager
    {
        public static void logMessage(String message, EventLogEntryType logType)
        {
            if (!EventLog.SourceExists("Sean"))
                EventLog.CreateEventSource("Sean","Application");

            EventLog.WriteEntry("Sean", message, logType);

            if (logType == EventLogEntryType.Error)
                Console.Error.WriteLine("*** ERR : " + message);

            try
            { 
                File.AppendAllLines("SeanLIbraryLog.txt",new string[]{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " :: " + message });
            }
            catch (Exception e)
            {
                EventLog.WriteEntry("Sean", "Cannot write to log file ---> " + e.Message);
                //throw;
            }
            
            
        }
       

    }
}
