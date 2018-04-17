using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
   public class DetectionEventArgs: EventArgs
   {
      public List<Track> _trackliste;
      public DetectionEventArgs(List<Track> traskliste)
      {
         _trackliste = traskliste;
      }
   }

   public interface IDetection
   {
      event EventHandler<DetectionEventArgs> DetectionReady;
   }

   public class DetectionFactory
   {
      //public static IDetection CreateDetection()
      //{
         
      //}
   }
}
