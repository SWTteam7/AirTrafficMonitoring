using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public interface IConversion
   {
      List<Track> ConvertTrack(List<string> trackliste);
   }
}
