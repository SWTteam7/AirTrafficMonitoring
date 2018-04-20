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
   public class FiltreringUnitTest
   {
       private IFiltrering _uut;
       private TrackObjectificationSoftware _track;
      // private ITransponderReceiver TransponderReciever;

        [SetUp]
       public void Setup()
       {
           _uut = new Filtrering();
           _track = Substitute.For<TrackObjectificationSoftware>();
          // TransponderReciever = Substitute.For<ITransponderReceiver>();
          
           //var trackliste = new List<string>();
           //trackliste.Add(_track);
            
        }

       [TestCase(9999,9999,false)]
       [TestCase(10000, 10000, true)]
       [TestCase(10001,10001,true)]
        public void SetsState_FlightStateAsExcepted_FilteredCorrect(int x, int y, bool expectedState)
       {
         Track t = new Track() {XCoor = x, YCoor = y};
         Assert.That(_uut.Filter(t), Is.EqualTo(expectedState));
       }

   }
}
