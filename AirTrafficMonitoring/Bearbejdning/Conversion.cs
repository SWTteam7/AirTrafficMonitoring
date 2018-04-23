using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
   public class Conversion:IConversion
   {
      private IFiltrering _filter;
      private List<Track> convertList;
      public Conversion(ITransponderReceiver itr, IFiltrering filter)
      {
         itr.TransponderDataReady += Receiver_TransponderDataReady;
         _filter = filter;
      }

      public Conversion() { }
         
      private void Receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
      {
         var list = e.TransponderData;
         convertList = ConvertTrack(list);
         _filter.Filter(convertList);
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
