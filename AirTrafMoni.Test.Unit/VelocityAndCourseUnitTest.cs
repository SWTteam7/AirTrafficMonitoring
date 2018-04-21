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
   class VelocityAndCourseUnitTest
   {
      private IVelocityAndCourse _uut;

      [SetUp]
      public void SetUp()
      {
         _uut = new VelocityAndCourse();
      }

      [Test]
      public void CalculateVelocityAndCourse_FlyIBeggeLister_Course_Correct()
      {
         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Timestamp = DateTime.Now.AddSeconds(-1);

         Track t2 = new Track();
         t2.Tag = "ABC";
         t2.XCoor = 50001;
         t2.YCoor = 50000;
         t2.Timestamp = DateTime.Now;
         

         List<Track> gammelliste = new List<Track>();
         List<Track> nyliste = new List<Track>();

         gammelliste.Add(t1);
         nyliste.Add(t2);

         List<Track> VClist = _uut.CalculateVelocityAndCourse(gammelliste, nyliste);

         Assert.That(VClist[0].Compasscourse, Is.EqualTo(90.0));
      }

      [Test]
      public void CalculateVelocityAndCourse_FlyIBeggeLister_Velocity_Correct()
      {
         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Timestamp = DateTime.Now.AddSeconds(-1);

         Track t2 = new Track();
         t2.Tag = "ABC";
         t2.XCoor = 50001;
         t2.YCoor = 50000;
         t2.Timestamp = DateTime.Now;
         

         List<Track> gammelliste = new List<Track>();
         List<Track> nyliste = new List<Track>();

         gammelliste.Add(t1);
         nyliste.Add(t2);

         List<Track> VClist = _uut.CalculateVelocityAndCourse(gammelliste, nyliste);

         Assert.That(VClist[0].Velocity, Is.EqualTo(1));
      }

      [Test]
      public void CalculateVelocityAndCourse_FlyIÉnLister_Course_Correct()
      {
         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Timestamp = DateTime.Now;

         Track t2 = new Track();
         t2.Tag = "DEF";
         t2.XCoor = 50001;
         t2.YCoor = 50000;
         t2.Timestamp = DateTime.Now;
         t2.Timestamp.AddSeconds(10);

         List<Track> gammelliste = new List<Track>();
         List<Track> nyliste = new List<Track>();

         gammelliste.Add(t1);
         nyliste.Add(t2);

         List<Track> VClist = _uut.CalculateVelocityAndCourse(gammelliste, nyliste);

         Assert.That(VClist[0].Compasscourse, Is.EqualTo(0));
      }

      [Test]
      public void CalculateVelocityAndCourse_FlyIÉnLister_Velocity_Correct()
      {
         Track t1 = new Track();
         t1.Tag = "ABC";
         t1.XCoor = 50000;
         t1.YCoor = 50000;
         t1.Timestamp = DateTime.Now.AddSeconds(-1);

         Track t2 = new Track();
         t2.Tag = "DEF";
         t2.XCoor = 50001;
         t2.YCoor = 50000;
         t2.Timestamp = DateTime.Now;


         List<Track> gammelliste = new List<Track>();
         List<Track> nyliste = new List<Track>();

         gammelliste.Add(t1);
         nyliste.Add(t2);

         List<Track> VClist = _uut.CalculateVelocityAndCourse(gammelliste, nyliste);

         Assert.That(VClist[0].Velocity, Is.EqualTo(0));
      }

   }
}
