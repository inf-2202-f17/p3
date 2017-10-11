using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemWideFileAccessLog
{
    /// <summary>
    /// Represents a log entry for system wide file access logs.
    /// Used in exercise 2. You need to finish this implementation.
    /// You can look to the PerFileAccessLog project for inspiration.
    /// </summary>
    public class SystemWideLogEntry
    {
        //DateTime of access, Region, TenantName, UserName, FileName, Status, Exception
        private readonly string formatString = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}" + Environment.NewLine;

        /// <summary>
        /// Should return a SystemWide log entry. Should respect status and date parameters.
        /// If status is Error, exception should be included (hint: Bogus has a System.Exception dataset)
        /// </summary>
        /// <param name="date">The date for which the entry should be created.</param>
        /// <param name="status">The status of the log entry.</param>
        public SystemWideLogEntry(DateTime date, FileAccessStatus status)
        {
            // Implement this
            throw new NotImplementedException();
        }

        /// <summary>
        /// Should return a SystemWide log entry. Should respect date parameter, and 
        /// a fraction of the log entries returned from this constructor should have Error status
        /// and some exception.
        /// </summary>
        /// <param name="date"></param>
        public SystemWideLogEntry(DateTime date)
        {
            // Implement this
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // Implement this. Tip: Enums have .ToString() built in.
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Possible statuses for file access operations.
    /// </summary>
    public enum FileAccessStatus
    {
        OK,
        Error
    }
}
