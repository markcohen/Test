using System;
using System.Text;

namespace GitTest.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to a UTF8-encoded byte array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        /// Converts a hex string to a byte array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] GetBytesFromHex(this string s)
        {
            throw new NotImplementedException();
        }
    }
}