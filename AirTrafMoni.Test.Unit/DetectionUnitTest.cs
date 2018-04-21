using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafMoni.Test.Unit
{
   [TestFixture]
   class DetectionUnitTest
   {
      private Detection _uut;
      private FakeCompare compare;
      private ILogging log;
      private IWriter writer;


      [SetUp]
      public void SetUp()
      {
         log = Substitute.For<ILogging>();
         compare = new FakeCompare();
         writer = Substitute.For<IWriter>();
         _uut = new Detection(compare, log, writer);

         Track t1 = new Track();
         t1.Tag = "ABC";

         t1.Timestamp = DateTime.Now;

         Track t2 = new Track();
         t2.Tag = "DEF";
         
         
         compare.ConflictingTracks.Add(t1);
         compare.ConflictingTracks.Add(t2);

         _uut.Update();
      }


      [Test]
      public void Update_TagOne_correct()
      {
         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Tag.Contains("ABC")));
      }

      [Test]
      public void Update_TagTwo_correct()
      {
         
         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[1].Tag.Contains("DEF")));
      }

      [Test]
      public void Update_TimeStamp_year_correct()
      {
         var timestamp = compare.ConflictingTracks[0].Timestamp;
         writer.Received().PrintConflictingTracks(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Equals(timestamp)));
      }
   }


   class FakeCompare: Compare
   {
      public void CompareTracks(List<Track> trackliste)
      {
         
      }
   }
}
