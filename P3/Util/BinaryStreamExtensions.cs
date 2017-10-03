namespace Util
{
    using System.IO;

    /// <summary>
    /// BinaryReader extensions to conveniently read all bytes.
    /// </summary>
    public static class BinaryReaderExtensions
    {
        private const int BufferSize = 8192;

        /// <summary>
        /// Reads all bytes from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader.</param>
        /// <returns>A byte array containing all bytes.</returns>
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            using (var memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[BufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memoryStream.Write(buffer, 0, count);
                }

                return memoryStream.ToArray();
            }
        }
    }
}