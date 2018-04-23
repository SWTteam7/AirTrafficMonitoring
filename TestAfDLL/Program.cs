using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using TransponderReceiver;

namespace Application
{
   class Program
   {
      static void Main(string[] args)
      {
         ITransponderReceiver itr =TransponderReceiverFactory.CreateTransponderDataReceiver();

         ILogging log = new Logging();
         IWriter writer = new ConsoleWriter();
         Compare com = new Compare();
         IVelocityAndCourse VC = new VelocityAndCourse(com,writer);
         IFiltrering filtrering = new Filtrering(VC);
         IConversion convertering = new Conversion(itr,filtrering);
         Detection detection = new Detection(com, log, writer);

         Console.ReadKey();
      }

      
   }
}
