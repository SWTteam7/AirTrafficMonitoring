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
         TrackObjectificationSoftware TOS = new TrackObjectificationSoftware(itr);
         TOS.readfromDLL();
         //TOS.Print();

         Console.ReadKey();
      }

      
   }
}
