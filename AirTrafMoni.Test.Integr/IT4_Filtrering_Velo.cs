using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using AirTrafficMonitoring;

namespace AirTrafMoni.Test.Integr
{
    [TestFixture]
    class IT4_Filtrering_Velo
    {

        private Filtrering _uut;
        private IVelocityAndCourse velo;
        private Compare compare;
        private IWriter writer;

        [SetUp]
        public void SetUp()
        {
            writer = Substitute.For<IWriter>();
            compare = new Compare();
            velo = new VelocityAndCourse(compare, writer);
            _uut = new Filtrering(velo);
        }

        [Test]
        public void Filter_FlyIndenFor()
        {
            Track t1 = new Track();
            t1.Tag = "ABC";
            t1.XCoor = 50000;
            t1.YCoor = 50000;
            t1.Altitude = 4000;
            t1.Timestamp = DateTime.Now;

            List<Track> liste = new List<Track>();
            liste.Add(t1);


            _uut.Filter(liste);

            Assert.That(velo.VelocityAndCourseListe.Count, Is.EqualTo(1));

        }

    }
}
