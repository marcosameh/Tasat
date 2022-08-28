using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicData.Admin.Infrastructure
{
    public class AccountUtility
    {

        /// <summary>
        /// Encode Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncodePassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in encoding password" + ex.Message);
            }
        }

        /// <summary>
        /// Decode Password
        /// </summary>
        /// <param name="encodedData"></param>
        /// <returns></returns>
        public static string DecodePassword(string encodedData)
        {
            string result = string.Empty;
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                result = new String(decoded_char);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in decoding password" + ex.Message);
            }
            return result;
        }
    }
}