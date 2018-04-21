using System;
using System.CodeDom;
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
   public class TrackObjectSoftwareUnitTest
   {
      private TrackObjectificationSoftware _uut;
      private ITransponderReceiver TransponderReciever;
      private IWriter writer;
      private Compare Compare;
      private IConversion convert;
      private IFiltrering filter;
      private IVelocityAndCourse velo;


      [SetUp]
      public void SetUp()
      {
         writer = Substitute.For<IWriter>();
         TransponderReciever= Substitute.For<ITransponderReceiver>();
         Compare = Substitute.For<Compare>();
         _uut = new TrackObjectificationSoftware(TransponderReciever,writer,Compare,convert,filter, velo);

         var track = "ATR423;11111;22222;33333;20180409095330123";
         var trackliste = new List<string>();
         trackliste.Add(track);

         var eventArgs = new RawTransponderDataEventArgs(trackliste);

         TransponderReciever.TransponderDataReady += Raise.EventWith(eventArgs);
      }
     

        //[Test]
      public void Transponder_reciever_TagCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Tag.Contains("ATR423")));
      }

      //[Test]
      public void Transponder_reciever_XCoorCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].XCoor.Equals(11111)));
      }

      //[Test]
      public void Transponder_reciever_YCoorCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].YCoor.Equals(22222)));
      }

      //[Test]
      public void Transponder_reciever_AltitudeCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Altitude.Equals(33333)));
      }
      //[Test]
      public void Transponder_reciever_TimeStampYearCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Year.Equals(2018)));
      }

      //[Test]
      public void Transponder_reciever_TimeStampMonthCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Month.Equals(04)));
      }

      //[Test]
      public void Transponder_reciever_TimeStampDayCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Day.Equals(09)));
      }

      //[Test]
      public void Transponder_reciever_TimeStampHourCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Hour.Equals(09)));
      }

      //[Test]
      public void Transponder_reciever_TimeStampMinutesCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Minute.Equals(53)));
      }

      //[Test]
      public void Transponder_reciever_TimeStampSecondsCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Second.Equals(30)));
      }

      //[Test]
      public void Transponder_reciever_TimeStampMiliSecondsCorrect()
      {
         writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Timestamp.Millisecond.Equals(123)));
      }
   }
}
