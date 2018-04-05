﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class TrackObjectificationSoftware
    {

       public TrackObjectificationSoftware(ITransponderReceiver itr)
       {
         itr.TransponderDataReady += Receiver_TransponderDataReady;
       }

     

      public void readfromDLL()
       {
          var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

          receiver.TransponderDataReady += Receiver_TransponderDataReady;
       }



       private static void Receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
       {
         var list = e.TransponderData;
          
         foreach (var track in list)
         {
            List<Track> Trackliste = new List<Track>();
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

            foreach (var _t in Trackliste)
            {
               _t.PrintData();
            }
         }
         
       }

       
    }
}
