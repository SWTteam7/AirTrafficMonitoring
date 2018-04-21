using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NUnit.Framework;

namespace AirTrafMoni.Test.Unit
{
   [TestFixture]
   class CompareUnitTest
   {
      private Compare _uut;

      [SetUp]
      public void SetUp()
      {
         _uut = new Compare();
      }

      [TestCase(50000,4000,55001,4301,0)]
      [TestCase(50000,4000,55001,4300,0)]
      [TestCase(50000,4000,55000,4301,0)]
      [TestCase(50000,4000,55000,4300,2)]
      public void CompareTracks_ToTracks(int x1, int alt1, int x2, int alt2, int count)
      {
         Track t1 = new Track();
         t1.XCoor = x1;
         t1.YCoor = 50000;
         t1.Altitude = alt1;

         Track t2 = new Track();
         t2.XCoor = x2;
         t2.YCoor = 50000;
         t2.Altitude = alt2;

         List<Track> trackliste = new List<Track>();

         trackliste.Add(t1);
         trackliste.Add(t2);

         _uut.CompareTracks(trackliste);

         Assert.That(_uut.ConflictingTracks.Count, Is.EqualTo(count));
      }
   }
}
