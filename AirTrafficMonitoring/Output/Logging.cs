using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Logging
    {
        public void logToFile(List<Track> conflictingFlights)
        {
            FileStream output = new FileStream("logfile.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter fileWriter = new StreamWriter(output);
            fileWriter.WriteLine("Conflicting flights: " + conflictingFlights[0].Tag + " and " + conflictingFlights[0].Tag + ". \nTime of occurrence: " +
                                 conflictingFlights[0].Timestamp.Year + "/" + conflictingFlights[0].Timestamp.Month + "/" + conflictingFlights[0].Timestamp.Day +
                                 ", at " + conflictingFlights[0].Timestamp.Hour + ":" + conflictingFlights[0].Timestamp.Minute + ":" +
                                 conflictingFlights[0].Timestamp.Second + " and " + conflictingFlights[0].Timestamp.Millisecond + " milliseconds");
            fileWriter.Close();
        }

       
    }
}
