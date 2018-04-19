using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class VelocityAndCourse
   {
       private double velocity;
       private double course;


       public List<Track> CalculateVelocityAndCourse(List<Track> gammelliste, List<Track>nyliste)
       {
            List<Track> VelocityAndCourseListe = new List<Track>();

           
           foreach (var track in nyliste)
           {
               if (gammelliste == null)
               {
                   track.Velocity = 0;
                   track.Compasscourse = 0;
                   VelocityAndCourseListe.Add(track);
               }

                for (int i = 0; i < gammelliste.Count; i++)
               {
                   if (track.Tag == gammelliste[i].Tag)
                   {
                       
                       double horisontaldistance = Math.Sqrt((Math.Pow((track.XCoor - gammelliste[i].XCoor), 2)) + (Math.Pow((track.YCoor - gammelliste[i].YCoor), 2)));
                       TimeSpan tidsforskel = track.Timestamp-gammelliste[i].Timestamp;
                       double tidMellemTracks = tidsforskel.TotalSeconds;
                       velocity = horisontaldistance / tidMellemTracks;

                       track.Velocity = velocity;

                       double BX = gammelliste[i].XCoor;
                       double BY = 90000;
                       double a = 90000 - gammelliste[i].YCoor;

                       double c = Math.Sqrt((Math.Pow((track.XCoor - BX), 2)) + (Math.Pow((track.YCoor - BY), 2)));

                       double course = Math.Acos((Math.Pow(a, 2) + Math.Pow(horisontaldistance, 2) - Math.Pow(c, 2)) /
                                                 2 * a * horisontaldistance);

                       track.Compasscourse = course;
                        
                       VelocityAndCourseListe.Add(track);
                   }
                  
               }
               
           }

           return VelocityAndCourseListe;

       }


       //sammenligne x og y koordinat og sammenligne timestamp med hinanden for at regne farten ud. 

   }
}
