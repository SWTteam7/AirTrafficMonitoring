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
  public class ConversionUnitTest
   {
      private IConversion _uut;
      private List<string> trackliste;
      private List<Track> convertliste;

      [SetUp]
      public void SetUp()
      {
         _uut=new Conversion();
         string track = "ATR423;11111;22222;33333;20180409095330123";

         trackliste = new List<string>();

         trackliste.Add(track);
         convertliste = _uut.ConvertTrack(trackliste);
      }

      [Test]
      public void ConvertTrack_Tag_isCorrect()
      {
         Assert.That(convertliste[0].Tag, Is.EqualTo("ATR423"));
      }

      [Test]
      public void ConvertTrack_XCoor_isCorrect()
      {
         Assert.That(convertliste[0].XCoor, Is.EqualTo(11111));
      }

      [Test]
      public void ConvertTrack_YCoor_isCorrect()
      {
         Assert.That(convertliste[0].YCoor, Is.EqualTo(22222));
      }

      [Test]
      public void ConvertTrack_Altitude_isCorrect()
      {
         Assert.That(convertliste[0].Altitude, Is.EqualTo(33333));
      }

      [Test]
      public void ConvertTrack_Timestamp_Year_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Year, Is.EqualTo(2018));
      }
      [Test]
      public void ConvertTrack_Timestamp_Month_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Month, Is.EqualTo(04));
      }

      [Test]
      public void ConvertTrack_Timestamp_Day_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Day, Is.EqualTo(09));
      }

      [Test]
      public void ConvertTrack_Timestamp_Hour_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Hour, Is.EqualTo(09));
      }

      [Test]
      public void ConvertTrack_Timestamp_Minutes_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Minute, Is.EqualTo(53));
      }

      [Test]
      public void ConvertTrack_Timestamp_Second_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Second, Is.EqualTo(30));
      }

      [Test]
      public void ConvertTrack_Timestamp_Millisecond_isCorrect()
      {
         Assert.That(convertliste[0].Timestamp.Millisecond, Is.EqualTo(123));
      }
   }
}
