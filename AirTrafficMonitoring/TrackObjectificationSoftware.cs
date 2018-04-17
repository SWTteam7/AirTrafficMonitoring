using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class TrackObjectificationSoftware
    {
       private static IWriter _writer;
       private Compare _com;
       

       public TrackObjectificationSoftware(ITransponderReceiver itr, IWriter writer, Compare com)
       {
         itr.TransponderDataReady += Receiver_TransponderDataReady;
          _writer = writer;
          _com = com;
       }


       private void Receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
       {
         var list = e.TransponderData;
          List<Track> Trackliste = new List<Track>();

         foreach (var track in list)
         {
            Convertion convertion = new Convertion();
            Track tr = convertion.ConvertTrack(track);

            //Tilføjer til liste
            Trackliste.Add(tr);
            //Printer Track
            _writer.PrintTrack(tr);
         }

         //Hvis der er mere end 1 track sammenligner den trackene
          if (Trackliste.Count > 1)
          {
             _com.CompareTracks(Trackliste);
          }
       }
    }
}
