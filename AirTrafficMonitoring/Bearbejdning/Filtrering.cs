using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Filtrering:IFiltrering
    {
       private IVelocityAndCourse _velo;
       private List<Track> gammelliste;
        private List<Track> veloliste;
       public List<Track> Filtreretliste { get; set; }
      
       public Filtrering() { }

       public Filtrering(IVelocityAndCourse velo)
       {
          _velo = velo;
         gammelliste = new List<Track>();
         

        }
        public void Filter(List<Track> trackliste)
        {
            
            Filtreretliste = new List<Track>();

            foreach (var tr in trackliste)
            {
                if (tr.XCoor <= 90000 && tr.XCoor >= 10000)
                {
                    if (tr.YCoor <= 90000 && tr.YCoor >= 10000)
                    {
                       if (tr.Altitude > 500 && tr.Altitude < 20000)
                       {
                          Filtreretliste.Add(tr);
                       }
                    }
                }
            }

            veloliste = new List<Track>();
            veloliste = _velo.CalculateVelocityAndCourse(gammelliste,Filtreretliste);

            gammelliste = veloliste;
        }
    }
}
