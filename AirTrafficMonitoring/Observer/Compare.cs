using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class Compare:ConflictingSubject
   {
      public Compare() {ConflictingTracks = new List<Track>(); }

      public List<Track> ConflictingTracks { get; set; }
      public void CompareTracks(List<Track> trackliste)
      {
         int verticalDistance;
         double horisontalDistance;
         //ConflictingTracks = new List<Track>();

         //Kigger på hvert track i listen
         for (int i=0; i<trackliste.Count;i++)
         {
            //Gennemgår alle de andre fly i listen for at finde konflikter
            for (int j = i+1; j < trackliste.Count; j++)
            {
               
               int X = trackliste[i].XCoor;
               int Y = trackliste[i].YCoor;
               int X2 = trackliste[j].XCoor;
               int Y2 = trackliste[j].YCoor;

               

                  //Udregner den horisontale distance
                  horisontalDistance = Math.Sqrt((Math.Pow((X2 - X), 2)) + (Math.Pow((Y2 - Y), 2)));

                  if (horisontalDistance <=5000)
                  {
                     int alt = trackliste[i].Altitude;
                     int alt2 = trackliste[j].Altitude;

                     //Udregner vertikal distance
                     verticalDistance = alt2 - alt;

                     if (verticalDistance <= 300 && verticalDistance >= -300)
                     {
                        //Hvis begge kriterer er opfyldt får vi tilføjet flyene til ConfligtingTrack list
                        
                        ConflictingTracks.Add(trackliste[i]);
                        ConflictingTracks.Add(trackliste[j]);
                        Notify();
                        
                     }
                  }
               
            }
         }
         //ConflictingTracks.Clear();
      }
   }
}
