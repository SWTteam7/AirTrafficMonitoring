using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafMoni.Test.Unit
{
   [TestFixture]
   class LoggingUnitTest
   {
      private ILogging _uut;
      

      [SetUp]
      public void SetUp()
      {
         _uut = new Logging();
         File.WriteAllText("logfile.txt", string.Empty);
      }

      [Test]
      public void LogToFile_TwoFlight_conflicting()
      {
         //[TestCase(50000, 4000, 55000, 4300, 2)]
         Track t1 = new Track();
         t1.Tag = "ABC";
        
         t1.Timestamp = new DateTime(2017,04,23,12,18,30,123);


         Track t2 = new Track();
         t2.Tag = "DEF";
         t1.Timestamp = new DateTime(2017, 04, 23, 12, 18, 30, 123);

         List<Track> liste = new List<Track>();
         liste.Add(t1);
         liste.Add(t2);

         _uut.logToFile(liste);

         var fileText = File.ReadAllLines("logfile.txt");

         var fil = fileText[0];

         Assert.That(fil,
            Is.EqualTo(
               "ALARM!!!! Conflicting flights: ABC, DEF Time stamp: 2017/4/23, at 12:18:30 and 123 milliseconds"));
      }
   }
}
