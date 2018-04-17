using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Detection:IConflictingObserver
    {
        private Compare _com;

       public Detection(Compare com)
       {
          _com = com;
         _com.Attach(this);
       }
        public void Update()
        {
           List<Track> conflictflights = _com.ConflictingTracks;
           Console.WriteLine("ALARM!!!!\nConflicting flights: " +conflictflights[0].Tag +", "+conflictflights[1].Tag+"\nTime: "+conflictflights[0].Timestamp.printTime()+"\n");
        }

         


      }
}
