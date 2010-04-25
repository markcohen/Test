using System;
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

        /// <summary>
        /// Converts a byte array to a lowercase hex string
        /// </summary>
        /// <param name="bData"></param>
        /// <returns></returns>
        public static string GetHexString(this byte[] bData)
        {
            return BitConverter.ToString(bData).Replace('-', '\x20').ToLower();
        }

        /// <summary>
        /// Converts a byte array to a base64 string
        /// </summary>
        /// <param name="bData"></param>
        /// <param name="base64FormattingOptions">Formatting options for the base64 output. Defaults to <code>None</code></param>
        /// <returns></returns>
        public static string GetBase64String(this byte[] bData, Base64FormattingOptions base64FormattingOptions = Base64FormattingOptions.None)
        {
            return Convert.ToBase64String(bData, base64FormattingOptions);
        }
    }
}