using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class TrackObjectificationSoftware
    {
       private static IWriter _writer;
       private Compare _com;
        private List<Track> gamleliste;
       

       public TrackObjectificationSoftware(ITransponderReceiver itr, IWriter writer, Compare com)
       {
         itr.TransponderDataReady += Receiver_TransponderDataReady;
          _writer = writer;
          _com = com;
          gamleliste = new List<Track>();
          
       }

        
       private void Receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
       {
         var list = e.TransponderData;
           List<Track> converteretliste= new List<Track>();
           List<Track> filtreretliste = new List<Track>();
           List<Track> færdigliste = new List<Track>();

          

        //Convertering
        Conversion convertion = new Conversion();
         converteretliste = convertion.ConvertTrack(list);

         //Filtrering  
         Filtrering filtrering = new Filtrering();
         filtreretliste = filtrering.Filter(converteretliste);

         VelocityAndCourse VC = new VelocityAndCourse();
         færdigliste=VC.CalculateVelocityAndCourse(gamleliste, filtreretliste);

         //Printer Track
         _writer.PrintTrack(færdigliste);

           gamleliste = færdigliste;

            //Hvis der er mere end 1 track sammenligner den trackene
            if (færdigliste.Count > 1)
         {
            _com.CompareTracks(færdigliste);
         }

           
       }
    }
}
