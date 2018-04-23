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
   public class IT1_Detection_Logger
   {
      private Detection _uut;
      private IWriter writer;
      private ILogging logger;
      private Compare compare;

      [SetUp]
      public void SetUp()
      {
         writer = Substitute.For<IWriter>();
         logger = new Logging();
         compare = Substitute.For<Compare>();
         _uut = new Detection(compare, logger, writer);
      }

      [Test]
      public void Update_Conflicting_LogtoFile()
      {

         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.Timestamp = new DateTime(2017, 04, 23, 12, 18, 30, 123);

         Track t2 = new Track();
         t2.Tag = "DEF";
         t1.Timestamp = new DateTime(2017, 04, 23, 12, 18, 30, 123);

         List<Track> liste = new List<Track>();
         liste.Add(t1);
         liste.Add(t2);


         compare.ConflictingTracks = liste;
         _uut.Update();

         var fileText = File.ReadAllLines("logfile.txt");

         var fil = fileText[0] + fileText[1] + fileText[2];

         Assert.That(fil,
            Is.EqualTo(
               "ALARM!!!!Conflicting flights: ABC, DEFTime stamp: 2017/4/23, at 12:18:30 and 123 milliseconds"));
      }
   }
}
