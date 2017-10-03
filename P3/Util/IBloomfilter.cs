using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// The interface of a bloom filter.
    /// You need to make an implementation of this interface in exercise 3.
    /// </summary>
    public interface IBloomfilter
    {
        /// <summary>
        /// Adds a item to the bloom filter.
        /// </summary>
        /// <param name="guid">The item to be added.</param>
        void Add(Guid guid);

        /// <summary>
        /// Returns whether or not an item is contained in the bloom filter.
        /// </summary>
        /// <param name="guid">The item to be checked for.</param>
        /// <returns>True if item is present, false if not.</returns>
        bool Contains(Guid guid);
    }
}
