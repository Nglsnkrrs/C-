using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_in_Stock
{
    public class ReportManager
    {

        public static void SaveReportToFile(List<Report> reportData, string reportName)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"{reportName}_{date}.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var item in reportData)
                {
                    writer.WriteLine(item.ToString());
                }
            }

            Console.WriteLine($"The report is saved to a file: {fileName}");
        }
    }
}
