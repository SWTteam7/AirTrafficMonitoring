using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class VelocityAndCourse:IVelocityAndCourse
   {
   private int velocity;
   private int course;

      public VelocityAndCourse()
      {
         
      }


   public List<Track> CalculateVelocityAndCourse(List<Track> gammelliste, List<Track>nyliste)
   {
      List<Track> VelocityAndCourseListe = new List<Track>();


      foreach (var track in nyliste)
      {

         for (int i = 0; i < gammelliste.Count; i++)
         {
            if (track.Tag == gammelliste[i].Tag)
            {

               //Velocity
               double horisontaldistance =
               Math.Sqrt((Math.Pow((track.XCoor - gammelliste[i].XCoor), 2)) +
                            (Math.Pow((track.YCoor - gammelliste[i].YCoor), 2)));
               TimeSpan tidsforskel = track.Timestamp - gammelliste[i].Timestamp;
               double tidMellemTracks = tidsforskel.TotalSeconds;
               velocity = Convert.ToInt32(horisontaldistance / tidMellemTracks);

               track.Velocity = velocity;


               //Course
               double BX = gammelliste[i].XCoor;
               double BY = 90000;
               double a = 90000 - gammelliste[i].YCoor;

               double c = Math.Sqrt((Math.Pow((track.XCoor - BX), 2)) + (Math.Pow((track.YCoor - BY), 2)));

               double courserad = Math.Acos((Math.Pow(a, 2) + Math.Pow(horisontaldistance, 2) - Math.Pow(c, 2)) / (
                                               2 * a * horisontaldistance));
               int course = Convert.ToInt32((courserad * 180) / Math.PI);

               track.Compasscourse = course;
            }
         }
         VelocityAndCourseListe.Add(track);

      }

      return VelocityAndCourseListe;

   }


   //sammenligne x og y koordinat og sammenligne timestamp med hinanden for at regne farten ud. 

   }
}
