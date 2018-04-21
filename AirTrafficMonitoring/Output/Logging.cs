using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Logging:ILogging
    {
      public void logToFile(List<Track> conflictflights)
      {
           FileStream output = new FileStream("logfile.txt", FileMode.Append, FileAccess.Write);
           StreamWriter fileWriter = new StreamWriter(output);
           fileWriter.WriteLine("ALARM!!!!\nConflicting flights: " + conflictflights[0].Tag + ", " + conflictflights[1].Tag + "\nTime stamp: " +
                                conflictflights[0].Timestamp.Year + "/" + conflictflights[0].Timestamp.Month + "/" + conflictflights[0].Timestamp.Day +
                                ", at " + conflictflights[0].Timestamp.Hour + ":" + conflictflights[0].Timestamp.Minute + ":" +
                                conflictflights[0].Timestamp.Second + " and " + conflictflights[0].Timestamp.Millisecond + " milliseconds\n");
           fileWriter.Close();
      }
    }
}
