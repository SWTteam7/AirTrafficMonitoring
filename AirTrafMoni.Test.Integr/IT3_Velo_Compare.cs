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
   }
}
