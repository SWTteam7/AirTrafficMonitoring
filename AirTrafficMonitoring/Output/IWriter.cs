using System.Collections.Generic;

namespace AirTrafficMonitoring
{
   public interface IWriter
   {
      void PrintTrack(List<Track> track);

      void PrintConflictingTracks(List<Track> conflictflights);
   }
}