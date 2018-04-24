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
   class ConflictingSubUnitTest
   {
      private ConflictingSubject _uut;

      [SetUp]
      public void Setup()
      {
         _uut = new ConflictingSubject();
      }


   }
}
