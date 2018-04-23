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
      private Compare _compare;
      private IWriter _writer;

      public VelocityAndCourse() { }

      public VelocityAndCourse(Compare compare, IWriter writer)
      {
         _compare = compare;
         _writer = writer;
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

               if (track.XCoor < gammelliste[i].XCoor)
               {
                  track.Compasscourse = 360 - course;
               }
               else track.Compasscourse = course;
            }
         }
         VelocityAndCourseListe.Add(track);

      }

      //Printer Track
      _writer.PrintTrack(VelocityAndCourseListe);


      //Hvis der er mere end 1 track sammenligner den trackene
      if (VelocityAndCourseListe.Count > 1)
      {
         _compare.CompareTracks(VelocityAndCourseListe);
      }

      return VelocityAndCourseListe;

   }


   }
}
