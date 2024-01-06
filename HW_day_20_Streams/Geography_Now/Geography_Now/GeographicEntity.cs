using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography_Now
{
    public abstract class GeographicEntity
    {
        public string CountryName { get; set; }
        public static void LogErrorMessage(string errorMessage)
        {
            string logFilePath = @"C: \Users\Kiu - Student\Desktop\Log.txt";
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"{DateTime.Now}: {errorMessage}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error while writing to log file: {ex.Message}");
            }
        }

    }
}
