using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class Track
   {
      public string Tag { get; set; }
      public int XCoor { get; set; }
      public int YCoor { get; set; }
      public int Altitude { get; set; }   
      public int Volocity { get; set; }     
      public int compasscourse { get; set; }
      public Timestamp Timestamp { get; set; }
   }
}
