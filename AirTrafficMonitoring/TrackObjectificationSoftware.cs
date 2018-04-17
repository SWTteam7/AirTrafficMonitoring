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
    public class TrackObjectificationSoftware:ConflictingSubject
    {
       private static IWriter _writer;
       private static IDetection _detection;

       public TrackObjectificationSoftware(ITransponderReceiver itr, IWriter writer)
       {
         itr.TransponderDataReady += Receiver_TransponderDataReady;
          _writer = writer;
          //_detection = iDetection;
       }


       private void Receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
       {
         var list = e.TransponderData;
          List<Track> Trackliste = new List<Track>();

         foreach (var track in list)
         {
            string[] _track;
            _track= track.Split(';');

            Track t = new Track();
            
            t.Tag = _track[0];
            t.XCoor = Convert.ToInt32(_track[1]);
            t.YCoor = Convert.ToInt32(_track[2]);
            t.Altitude = Convert.ToInt32(_track[3]);
            string time = _track[4];


            Timestamp timestamp = new Timestamp();
            timestamp.Year = time.Substring(0, 4);
            timestamp.Month = time.Substring(4, 2);
            timestamp.Day = time.Substring(6, 2);
            timestamp.Hour = time.Substring(8, 2);
            timestamp.Minute = time.Substring(10, 2);
            timestamp.Second = time.Substring(12, 2);
            timestamp.Milisecond = time.Substring(14, 3);

            t.Timestamp = timestamp;
            
            Trackliste.Add(t);

            
               _writer.PrintTrack(t);
            

            
         }
          if (Trackliste.Count > 1)
          {
             CompareTracks(Trackliste);
          }
      }

      public List<Track> ConflictingTracks { get; set; }
      public void CompareTracks(List<Track> trackliste)
       {
          int verticalDistance;
          double horisontalDistance;

          foreach (var track in trackliste)
          {
             for (int i = 0; i < trackliste.Count; i++)
             {
                int X = track.XCoor;
                int Y = track.YCoor;
                int X2 = trackliste[i].XCoor;
                int Y2 = trackliste[i].YCoor;

                if (X != X2 || Y != Y2)
                {
                   horisontalDistance = Math.Sqrt((Math.Pow((X2 - X), 2)) + (Math.Pow((Y2 - Y), 2)));

                   if (horisontalDistance < 5000)
                   {
                      int alt = track.Altitude;
                      int alt2 = trackliste[i].Altitude;

                      verticalDistance = alt2 - alt;

                      if (verticalDistance < 300 && verticalDistance>-300)
                      {
                         ConflictingTracks = new List<Track>();
                         ConflictingTracks.Add(track);
                         ConflictingTracks.Add(trackliste[i]);
                         Notify();



                         //måske skal vi ikke bruge observe men bare her starte eventet... er bare ikke sikker på hvordan man gør.
                      }
                   }
                }
                

             }
          }

       }
    }
}
