using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafMoni.Test.Integr
{
   [TestFixture]
   class IT2_Compare_Detection
   {
      private Compare _uut;
      private Detection detection;
      private ILogging log;
      private IWriter writer;
      private List<Track> liste;


      [SetUp]
      public void SetUp()
      {
         log = new Logging();
         writer = Substitute.For<IWriter>();
         _uut = new Compare();
         detection = new Detection(_uut,log,writer);
         

         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Altitude = 4000;
         t1.Timestamp = new DateTime(2017, 04, 23, 12, 18, 30, 123);

         Track t2 = new Track();
         t2.Tag = "DEF";
         t2.XCoor = 55000;
         t2.YCoor = 50000;
         t2.Altitude = 4300;


         liste = new List<Track>();
         liste.Add(t1);
         liste.Add(t2);

         File.WriteAllText("logfile.txt", string.Empty);
      }

      [Test]
      public void CompareTracks_NOTConflicting_LogtoFil()
      {
         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Altitude = 4000;
         t1.Timestamp = new DateTime(2018, 04, 23, 12, 18, 30, 123);

         Track t2 = new Track();
         t2.Tag = "DEF";
         t2.XCoor = 55001;
         t2.YCoor = 50000;
         t2.Altitude = 4301;
         t1.Timestamp = new DateTime(2018, 04, 23, 12, 18, 30, 123);

         List<Track> liste = new List<Track>();
         liste.Add(t1);
         liste.Add(t2);

         _uut.CompareTracks(liste);


         var fileText = File.ReadAllLines("logfile.txt");

        

         Assert.That(fileText.Length, Is.EqualTo(0));

      }

      [Test]
      public void CompareTracks_Conflicting_LogtoFil()
      {
         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Altitude = 4000;
         t1.Timestamp = new DateTime(2017, 04, 23, 12, 18, 30, 123);

         Track t2 = new Track();
         t2.Tag = "DEF";
         t2.XCoor = 55000;
         t2.YCoor = 50000;
         t2.Altitude = 4300;
         t2.Timestamp = new DateTime(2017, 04, 23, 12, 18, 30, 123);

         List<Track> liste = new List<Track>();
         liste.Add(t1);
         liste.Add(t2);

         _uut.CompareTracks(liste);


         var fileText = File.ReadAllLines("logfile.txt");

         var fil = fileText[0];

         Assert.That(fil,Is.EqualTo("ALARM!!!! Conflicting flights: ABC, DEF Time stamp: 2017/4/23, at 12:18:30 and 123 milliseconds"));
         
      }

      

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Tag1Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Tag.Equals("ABC")));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Tag2Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[1].Tag.Equals("DEF")));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_year_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Year.Equals(2017)));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_month_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Month.Equals(04)));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_day_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Day.Equals(23)));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_hour_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Hour.Equals(12)));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_minutes_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Minute.Equals(18)));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_second_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Second.Equals(30)));
      }

      [Test]
      public void CompareTracks_Conflicting_WriteToConsole_Time_millisecond_Correct()
      {
         _uut.CompareTracks(liste);

         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Millisecond.Equals(123)));
      }

   }
}
