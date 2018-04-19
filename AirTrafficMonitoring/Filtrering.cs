using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Filtrering
    {
        public List<Track> Filter(List<Track> trackliste)
        {
            List<Track> filtreretliste = new List<Track>();

            foreach (var tr in trackliste)
            {
                if (tr.XCoor < 90000 && tr.XCoor > 10000)
                {
                    if (tr.YCoor < 90000 && tr.YCoor > 10000)
                    {
                        filtreretliste.Add(tr);
                    }
                }
            }
            return filtreretliste;
        }
    }
}
