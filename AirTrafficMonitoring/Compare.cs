using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class Compare:ConflictingSubject
   {
      public List<Track> ConflictingTracks { get; set; }
      public void CompareTracks(List<Track> trackliste)
      {

         int verticalDistance;
         double horisontalDistance;


         //Kigger på hvert track i listen
         foreach (var track in trackliste)
         {

            //Gennemgår alle de andre fly i listen for at finde konflikter
            for (int i = 0; i < trackliste.Count; i++)
            {
               int X = track.XCoor;
               int Y = track.YCoor;
               int X2 = trackliste[i].XCoor;
               int Y2 = trackliste[i].YCoor;

               //Tjekker at det ikke er det samme track
               if (X != X2 || Y != Y2)
               {

                  //Udregner den horisontale distance
                  horisontalDistance = Math.Sqrt((Math.Pow((X2 - X), 2)) + (Math.Pow((Y2 - Y), 2)));

                  if (horisontalDistance < 10000)
                  {
                     int alt = track.Altitude;
                     int alt2 = trackliste[i].Altitude;

                     //Udregner vertikal distance
                     verticalDistance = alt2 - alt;

                     if (verticalDistance < 10000 && verticalDistance > -10000)
                     {
                        //Hvis begge kriterer er opfyldt får vi tilføjet flyene til ConfligtingTrack list
                        ConflictingTracks = new List<Track>();
                        ConflictingTracks.Add(track);
                        ConflictingTracks.Add(trackliste[i]);
                        Notify();
                     }
                  }
               }
            }
         }

      }
   }
}
