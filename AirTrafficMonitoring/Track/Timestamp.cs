using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class Timestamp
   {
      public string Year { get; set; }
      public string Month { get; set; }
      public string Day { get; set; }
      public string Hour { get; set; }
      public string Minute { get; set; }
      public string Second { get; set; }
      public string Milisecond { get; set; }


      public string printTime()
      {
         string time = Year +"/"+Month+"/" + Day+", at "+Hour+":"+Minute+":"+Second+" and "+Milisecond+" milliseconds";
         return time;
      }
   }
}
