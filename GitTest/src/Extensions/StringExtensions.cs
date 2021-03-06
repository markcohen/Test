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

        /// <summary>
        /// Converts a base64-encoded string to a byte array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] GetBytesFromBase64(this string s)
        {
            return Convert.FromBase64String(s);
        }

        /// <summary>
        /// Converts a string to a lowercase hex string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks>The string is first converted to a UTF8-encode byte array</remarks>
        public static string GetHex(this string s)
        {
            return s.GetBytes().GetHexString();
        }
    }
}