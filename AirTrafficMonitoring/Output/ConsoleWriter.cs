using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class ConsoleWriter:IWriter
   {
      public void PrintTrack(Track track)
      {
         
         Console.WriteLine("Tag: " + track.Tag + "\nX-coordinate: " + track.XCoor + "meters\nY-coordinate: " + track.YCoor + "meters\nAltitude: " + track.Altitude + "meters\nTime stamp: "+ track.Timestamp.Year + "/" + track.Timestamp.Month + "/" + track.Timestamp.Day + ", at " + track.Timestamp.Hour + ":" + track.Timestamp.Minute + ":" + track.Timestamp.Second + " and " + track.Timestamp.Milisecond + " milliseconds \n");


         
         
      }
   }
}
