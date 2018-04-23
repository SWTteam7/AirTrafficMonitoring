using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public interface IVelocityAndCourse
   {
      List<Track> CalculateVelocityAndCourse(List<Track> gammelliste, List<Track> nyliste);
        List<Track> VelocityAndCourseListe { get; set; }
    }
}
