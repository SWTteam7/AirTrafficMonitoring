using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using AirTrafficMonitoring;
using TransponderReceiver;

namespace AirTrafMoni.Test.Integr
{
    [TestFixture]
    class IT5_Conversion_Filter
    {
        private Conversion _uut;
        private IFiltrering filter;
        private ITransponderReceiver itr;
        private IVelocityAndCourse velo;
        private Compare com;
        private IWriter writer;

        [SetUp]
        public void Setup()
        {
            com = new Compare();
            writer = Substitute.For<IWriter>();
            velo = new VelocityAndCourse(com, writer);
            filter = new Filtrering(velo);
            itr = Substitute.For<ITransponderReceiver>();
            _uut = new Conversion(itr,filter);

            string t1 = "ATR423;11111;22222;33333;20180409095330123";
            List<string> trackliste = new List<string>();
            trackliste.Add(t1);

            var eventArgs = new RawTransponderDataEventArgs(trackliste);
            itr.TransponderDataReady += Raise.EventWith(eventArgs);

        }

        [Test]
        public void ConvertTrack_Tjekfilterliste_EnIListe()
        {

            Assert.That(filter.Filtreretliste.Count,Is.EqualTo(1));
        }

       [Test]
       public void ConvertTrack_Tjek_Tag()
       {
          Assert.That(filter.Filtreretliste[0].Tag, Is.EqualTo("ATR423"));
       }


    }
}
