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
        Logging _log = new Logging();

        public Detection(Compare com)
       {
          _com = com;
         _com.Attach(this);
       }
        public void Update()
        {
           List<Track> conflictflights = _com.ConflictingTracks;
           Console.WriteLine("ALARM!!!!\nConflicting flights: " +conflictflights[0].Tag +", "+conflictflights[1].Tag+ "\nTime stamp: " +
                             conflictflights[1].Timestamp.Year + "/" + conflictflights[1].Timestamp.Month + "/" + conflictflights[1].Timestamp.Day +
                             ", at " + conflictflights[1].Timestamp.Hour + ":" + conflictflights[1].Timestamp.Minute + ":" +
                             conflictflights[1].Timestamp.Second + " and " + conflictflights[1].Timestamp.Millisecond + " milliseconds");
           Console.WriteLine("ALARM!!!\nConflicting flights: " + conflictflights[0].Tag + ", " + conflictflights[1].Tag + "\nTime: " + conflictflights[0].Timestamp.printTime() + "\n");
           _log.logToFile(conflictflights);

        }

         


      }
}
