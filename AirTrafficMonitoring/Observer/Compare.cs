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
         for (int i=0; i<trackliste.Count;i++)
         {
            //Gennemgår alle de andre fly i listen for at finde konflikter
            for (int j = i+1; j < trackliste.Count; j++)
            {
               
               int X = trackliste[i].XCoor;
               int Y = trackliste[i].YCoor;
               int X2 = trackliste[j].XCoor;
               int Y2 = trackliste[j].YCoor;

               //Tjekker at det ikke er det samme track
               if (X != X2 || Y != Y2)
               {

                  //Udregner den horisontale distance
                  horisontalDistance = Math.Sqrt((Math.Pow((X2 - X), 2)) + (Math.Pow((Y2 - Y), 2)));

                  if (horisontalDistance < 200000)
                  {
                     int alt = trackliste[i].Altitude;
                     int alt2 = trackliste[j].Altitude;

                     //Udregner vertikal distance
                     verticalDistance = alt2 - alt;

                     if (verticalDistance < 100000 && verticalDistance > -100000)
                     {
                        //Hvis begge kriterer er opfyldt får vi tilføjet flyene til ConfligtingTrack list
                        ConflictingTracks = new List<Track>();
                        ConflictingTracks.Add(trackliste[i]);
                        ConflictingTracks.Add(trackliste[j]);
                        Notify();
                     }
                  }
               }
            }
         }

      }
   }
}
