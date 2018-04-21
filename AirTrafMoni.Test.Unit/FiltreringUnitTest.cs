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
      
       [SetUp]
       public void Setup()
       {
           _uut = new Filtrering();
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

         List<Track> trackliste = new List<Track>();
         trackliste.Add(t);
          List<Track> filterliste = _uut.Filter(trackliste);

         Assert.That(filterliste.Count, Is.EqualTo(count));

        }

      


   }
}
