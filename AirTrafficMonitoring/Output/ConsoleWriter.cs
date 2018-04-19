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
   }
}
