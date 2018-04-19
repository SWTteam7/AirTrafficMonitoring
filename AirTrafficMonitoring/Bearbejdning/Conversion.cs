using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class Conversion:IConversion
   {
      public List<Track> ConvertTrack(List<string> trackliste)
      {
            List<Track> converteret = new List<Track>();
          foreach (var stringtrack in trackliste)
          {
              //splitter streng
              string[] _track;
              _track = stringtrack.Split(';');

              //Opretter nyt track
              Track t = new Track();
              //Convertere TransponderData til Track objekt
              t.Tag = _track[0];
              t.XCoor = Convert.ToInt32(_track[1]);
              t.YCoor = Convert.ToInt32(_track[2]);
              t.Altitude = Convert.ToInt32(_track[3]);
              

              t.Timestamp = DateTime.ParseExact(_track[4],"yyyyMMddHHmmssfff",System.Globalization.CultureInfo.InvariantCulture);
              t.Velocity = 0;
              t.Compasscourse = 0;

              //Timestamp timestamp = new Timestamp();
              //timestamp.Year = time.Substring(0, 4);
              //timestamp.Month = time.Substring(4, 2);
              //timestamp.Day = time.Substring(6, 2);
              //timestamp.Hour = time.Substring(8, 2);
              //timestamp.Minute = time.Substring(10, 2);
              //timestamp.Second = time.Substring(12, 2);
              //timestamp.Milisecond = time.Substring(14, 3);

              //t.Timestamp = timestamp;

              //Tilføjer til liste
              converteret.Add(t);
            }
          return converteret;
      }
      
   }
}
