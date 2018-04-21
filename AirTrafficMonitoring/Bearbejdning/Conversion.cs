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
      public Conversion()
      {
         
      }
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


              //Tilføjer til liste
              converteret.Add(t);
            }
          return converteret;
      }
      
   }
}
