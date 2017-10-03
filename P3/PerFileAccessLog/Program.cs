using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerFileAccessLog
{
    /// <summary>
    /// This program generates a per file access log.
    /// The output of size corresponding to argument one is put in the file given by argument two.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: PerFileAccessLog.exe SizeInMegabytes outputfile, e.g. PerFileAccessLog 1000 C:\\myoutputfile.csv");
            }

            int sizeInMb = -1;
            if (!Int32.TryParse(args[0], out sizeInMb) || sizeInMb < 1)
            {
                Console.WriteLine("Unable to parse size argument. Should be positive integer.");
            }

            string outputFile = args[1];

            var sizeInBytes = sizeInMb*1024*1024;
            var date = new DateTime(2015, 1, 1);
            var random = new Random();
            long bytes = 0;
            using (var outfile = System.IO.File.Open(outputFile, FileMode.CreateNew))
            {
                while (bytes < sizeInBytes)
                {
                    var numEntriesForDate = random.Next(0, 500000);
                    for (int i = 0; i < numEntriesForDate; i++)
                    {
                        var logEntry = new PerFileLogEntry(date);
                        var entryBytes = System.Text.Encoding.UTF8.GetBytes(logEntry.ToString());
                        outfile.Write(entryBytes, 0, entryBytes.Length);

                        bytes += entryBytes.Length;
                        if (bytes >= sizeInBytes)
                        {
                            break;
                        }
                    }
                    date = date.AddDays(1);
                }
            }
        }
    }
}
