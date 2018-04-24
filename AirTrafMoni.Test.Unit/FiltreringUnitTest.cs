using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafMoni.Test.Unit
{
   [TestFixture]
   public class FiltreringUnitTest
   {
       private IFiltrering _uut;
      private IVelocityAndCourse velo;
      
       [SetUp]
       public void Setup()
       {
          velo = Substitute.For<IVelocityAndCourse>();
           _uut = new Filtrering(velo);
       }

       [TestCase(9999,9999,0)]
       [TestCase(10000, 10000, 1)]
       [TestCase(9999,10000,0)]
       [TestCase(10000, 9999, 0)]
       [TestCase(90001, 90001, 0)]
       [TestCase(90000, 90000, 1)]
       [TestCase(90001, 90000, 0)]
       [TestCase(90000, 90001, 0)]
      public void SetsState_FlightStateAsExcepted_FilteredCorrect(int x, int y, int count)
      {
          Track t = new Track();
          t.XCoor = x;
          t.YCoor = y;
         t.Altitude = 5000;

          List<Track> trackliste = new List<Track>();
          trackliste.Add(t);
          _uut.Filter(trackliste);
          

          Assert.That(_uut.Filtreretliste.Count, Is.EqualTo(count));

      }

   }
}
