using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Detection:IConflictingObserver
    {
       private Compare _com;
       private ILogging _log;

       public Detection(Compare com, ILogging log)
       {
          _com = com;
          _log = log;
         _com.Attach(this);
         
       }
        public void Update()
        {
           List<Track> conflictflights = _com.ConflictingTracks;
           string output = "ALARM!!!!\nConflicting flights: " +conflictflights[0].Tag +", "+conflictflights[1].Tag+ "\nTime stamp: " +
                             conflictflights[0].Timestamp.Year + "/" + conflictflights[0].Timestamp.Month + "/" + conflictflights[0].Timestamp.Day +
                             ", at " + conflictflights[0].Timestamp.Hour + ":" + conflictflights[0].Timestamp.Minute + ":" +
                             conflictflights[0].Timestamp.Second + " and " + conflictflights[0].Timestamp.Millisecond + " milliseconds\n";

         Console.WriteLine(output);
         _log.logToFile(output);

        }

         


      }
}
