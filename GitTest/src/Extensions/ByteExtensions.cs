using System.Text;

namespace GitTest.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Converts a UTF8-encoded byte array to a string
        /// </summary>
        /// <param name="bData"></param>
        /// <returns></returns>
        public static string GetString(this byte[] bData)
        {
            return Encoding.UTF8.GetString(bData);
        }
    }
}