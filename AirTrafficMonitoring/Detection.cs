using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Detection:IConflictingObserver
    {
        private TrackObjectificationSoftware _TOS;

       public Detection(TrackObjectificationSoftware tos)
       {
          _TOS = tos;
         _TOS.Attach(this);
       }
        public void Update()
        {
           List<Track> conflictflights = _TOS.ConflictingTracks;
           Console.WriteLine("Conflicting flights: " +conflictflights[0].Tag +", "+conflictflights[1].Tag+"\nTime: "+conflictflights[0].Timestamp.printTime());
        }

         //Noget med eventet


      }
}
