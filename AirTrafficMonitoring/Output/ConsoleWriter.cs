using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class ConsoleWriter:IWriter
   {
      public void PrintTrack(List<Track> trackliste)
      {
         if (trackliste.Count != 0)
         {

            Console.WriteLine("-----------------------------------------------------------\n");

            foreach (var track in trackliste)
            {

               Console.WriteLine("Tag: " + track.Tag + "\nX-coordinate: " + track.XCoor + " meters\nY-coordinate: " +
                                 track.YCoor + " meters\nAltitude: " + track.Altitude + " meters\nTime stamp: " +
                                 track.Timestamp.Year + "/" + track.Timestamp.Month + "/" + track.Timestamp.Day +
                                 ", at " + track.Timestamp.Hour + ":" + track.Timestamp.Minute + ":" +
                                 track.Timestamp.Second + " and " + track.Timestamp.Millisecond +
                                 " milliseconds \nVelocity: " + track.Velocity + " m/s\nCourse: " +
                                 track.Compasscourse + " degrees\n");

            }
         }
      }

      public void PrintConflictingTracks(List<Track> conflictflights)
      {
         Console.WriteLine("ALARM!!!!\nConflicting flights: " + conflictflights[0].Tag + ", " + conflictflights[1].Tag + "\nTime stamp: " +
                         conflictflights[0].Timestamp.Year + "/" + conflictflights[0].Timestamp.Month + "/" + conflictflights[0].Timestamp.Day +
                         ", at " + conflictflights[0].Timestamp.Hour + ":" + conflictflights[0].Timestamp.Minute + ":" +
                         conflictflights[0].Timestamp.Second + " and " + conflictflights[0].Timestamp.Millisecond + " milliseconds\n");
      }

   }
}
