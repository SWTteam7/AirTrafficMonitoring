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
       private ILogging _log;
       private IWriter _writer;

       public Detection(Compare com, ILogging log, IWriter writer)
       {
          _writer = writer;
          _com = com;
          _log = log;
         _com.Attach(this);
         
       }
        public void Update()
        {
           List<Track> conflictflights = _com.ConflictingTracks;

           _writer.PrintConflictingTracks(conflictflights);
           _log.logToFile(conflictflights);

        }

         


      }
}
