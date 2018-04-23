using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public interface IFiltrering
   {
      void Filter(List<Track> trackliste);

      List<Track> Filtreretliste { get; set; }
   }
}
