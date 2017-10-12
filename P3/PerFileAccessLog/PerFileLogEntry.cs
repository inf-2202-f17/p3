using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Util;

namespace PerFileAccessLog
{
    /// <summary>
    /// Represents a log entry in the per-file logs.
    /// Used in exercise 3.
    /// </summary>
    public class PerFileLogEntry
    {
        DateTime Date;
        string Region;
        string TenantName;
        string FileName;
        string ModifyingUsers;
        DateTime FirstAccess;
        DateTime LastAccess;

        private readonly string formatString = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}" + Environment.NewLine;

        /// <summary>
        /// Creates a per-file log entry for the given date.
        /// </summary>
        /// <param name="date">The date for which the log entry should be created.</param>
        public PerFileLogEntry(DateTime date)
        {
            var random = new Random();
            this.Date = date.Date;
            this.Region = DataGeneration.GetRegion();
            this.TenantName = new Bogus.DataSets.Company().CompanyName();
            this.FileName = new Bogus.DataSets.System().FileName();
            this.ModifyingUsers = GenerateUsersString();
            this.FirstAccess = this.Date.AddHours(random.Next(0, 6))
                                        .AddMinutes(random.Next(0, 59))
                                        .AddSeconds(random.Next(0, 59));
            this.LastAccess = this.Date.AddHours(random.Next(18, 23))
                                        .AddMinutes(random.Next(0, 59))
                                        .AddSeconds(random.Next(0, 59));
        }

        /// <summary>
        /// Creates a string representing the log entry.
        /// </summary>
        /// <returns>The log entry in string form.</returns>
        public override string ToString()
        {
            return string.Format(formatString, this.Date, this.Region, this.TenantName, this.FileName,
                this.ModifyingUsers, this.FirstAccess, this.LastAccess);
        }
        
        /// <summary>
        /// Generates a JSON list representatin of a set of users represented by their email addresses.
        /// </summary>
        /// <returns></returns>
        private static string GenerateUsersString()
        {
            var random = new Random();
            var numUsers = random.Next(1, 1000);
            return JsonConvert.SerializeObject(UserEmail(numUsers));
        }

        private static IEnumerable<string> UserEmail(int numUsers)
        {
            var bogus = new Bogus.DataSets.Internet();
            for (int i = 0; i < numUsers; i++)
            {
                yield return bogus.Email();
            }
        }
    }   
}
