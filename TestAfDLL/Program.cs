﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TestAfDLL
{
   class Program
   {
      static void Main(string[] args)
      {
         var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

         receiver.TransponderDataReady += Receiver_TransponderDataReady;

         
      }

      private static void Receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
      {
         var list = e.TransponderData;

         foreach (var track in list)
         {
            Console.WriteLine(track);
         }
      }
   }
}