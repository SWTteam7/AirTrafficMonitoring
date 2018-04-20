using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Logging:ILogging
    {
      public void logToFile(string meddelelse)
      {
           FileStream output = new FileStream("logfile.txt", FileMode.Append, FileAccess.Write);
           StreamWriter fileWriter = new StreamWriter(output);
           fileWriter.WriteLine(meddelelse);
           fileWriter.Close();
      }
    }
}
