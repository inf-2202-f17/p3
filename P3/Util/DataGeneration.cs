using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// Implements data generation functions.
    /// To be used in exercise 1.
    /// 
    /// Tip: If you find code overlapping code between PerFileAccessLog and SystemWideAccessLog projects
    /// you should consider moving it here.
    /// </summary>
    public static class DataGeneration
    {
        private static readonly List<string> regions = new List<string> { "EUR", "CAN", "JPN", "US", "CHN", "GER", "APAC", "AUS" };

        private static readonly Random random = new Random();

        /// <summary>
        /// Gets a random region string from the set of regions.
        /// </summary>
        /// <returns></returns>
        public static string GetRegion()
        {
            return regions[random.Next(0, regions.Count - 1)];
        }

        /// <summary>
        /// Generates a string representation of a set of claims in Guid form.
        /// </summary>
        /// <param name="numclaims">The number of claims that should be present in the set.</param>
        /// <returns>The string representation of the set.</returns>
        static string GenerateStringClaims(int numClaims)
        {
            // Implement this.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a byte array representation of a set of claims in Guid form.
        /// </summary>
        /// <param name="numclaims">The number of claims that should be present in the set.</param>
        /// <returns>The byte array representation of the set.</returns>
        static byte[] GenerateByteArrayClaims(int numClaims)
        {
            // Implement this.
            throw new NotImplementedException();
        }
    }
}
