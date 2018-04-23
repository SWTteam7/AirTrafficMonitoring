using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafMoni.Test.Integr
{
   [TestFixture]
   class IT3_Velo_Compare
   {
      private IVelocityAndCourse _uut;
      private Compare com;
      private IWriter writer;
      
       

      [SetUp]
      public void Setup()
      {
         writer = Substitute.For<IWriter>();
         com = new Compare();
         _uut = new VelocityAndCourse(com, writer);
      }

        [Test]
        public void CalculateVelocityAndCourse_FlyIBeggeLister_90Course_Correct()
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

            _uut.CalculateVelocityAndCourse(gammelliste, nyliste);

            writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Compasscourse.Equals(90)));
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

            _uut.CalculateVelocityAndCourse(gammelliste, nyliste);

            writer.Received().PrintTrack(Arg.Is<List<Track>>(tra => tra[0].Velocity.Equals(1)));
        }

        [Test]
        public void CalculateVelocityAndCourse_Conflicting_TagOne_correct()
        {
            Track t1 = new Track();
            t1.Tag = "ABC";
            t1.XCoor = 50000;
            t1.YCoor = 50000;
            t1.Altitude = 4000;
            t1.Timestamp = DateTime.Now;


            Track t2 = new Track();
            t2.Tag = "DEF";
            t2.XCoor = 55000;
            t2.YCoor = 50000;
            t2.Altitude = 4300;
            t2.Timestamp = DateTime.Now;

            Track t3 = new Track();
            t3.Tag = "DEF";
            t3.Timestamp = DateTime.Now.AddSeconds(1);


            List<Track> nyliste = new List<Track>();
            List<Track> gammelliste = new List<Track>();
            

            nyliste.Add(t1);
            nyliste.Add(t2);
            gammelliste.Add(t3);

            _uut.CalculateVelocityAndCourse(gammelliste, nyliste);


            Assert.That(com.ConflictingTracks.Count, Is.EqualTo(2));

        }

    }
}
