using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private readonly string formatString = @"{0}, {1}, {2}, {3}, {4}, {5}, {6}" + Environment.NewLine;

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
        private string GenerateUsersString()
        {
            var random = new Random();
            var bogus = new Bogus.DataSets.Internet();
            var builder = new StringBuilder("[");

            var numUsers = random.Next(1, 1000);
            for (int i = 0; i < numUsers; i++)
            {
                builder.AppendFormat("{0},", bogus.Email());
            }

            builder.Remove(builder.Length - 2, 1);
            builder.Append("]");

            return builder.ToString();
        }
    }   
}
