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
         string timeprint = track.Timestamp.printTime();
         Console.WriteLine("Tag: " + track.Tag + "\nX-coordinate: " + track.XCoor + "meters\nY-coordinate: " + track.YCoor + "meters\nAltitude: " + track.Altitude + "meters\nTime stamp: " + timeprint + "\n");
      }
   }
}
