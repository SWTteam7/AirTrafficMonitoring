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
         
         IWriter writer = new ConsoleWriter();
         Compare com = new Compare();
         IFiltrering filtrering = new Filtrering();
         IConversion convertering = new Conversion();
         IVelocityAndCourse VC= new VelocityAndCourse();
         ILogging log = new Logging();

         TrackObjectificationSoftware TOS = new TrackObjectificationSoftware(itr,writer,com,convertering,filtrering,VC);

         Detection detection = new Detection(com, log);

         Console.ReadKey();
      }

      
   }
}
