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
         //IDetection detection = new 
         

         TrackObjectificationSoftware TOS = new TrackObjectificationSoftware(itr,writer);

         Detection detection = new Detection(TOS);

         Console.ReadKey();
      }

      
   }
}
