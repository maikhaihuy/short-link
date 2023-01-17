using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ShortLink.Common.Helpers
{
    public static class StringHelpers
    {
        public static string GetFileName(string filePath) => string.IsNullOrEmpty(filePath) ? filePath : filePath.Split("/").Last();
        
        public static bool SlugHasSpecialChar(this string input)
        {
            Regex regex = new Regex(@"^[a-z\d](?:[a-z\d_-]*[a-z\d])?$");

            return regex.IsMatch(input);
        }

        public static string GenerateUniqId(string diff = null)
        {
            string text = DateTime.Now.Ticks.ToString();
            if (!string.IsNullOrEmpty(diff))
                text = $"{text}{diff}";
            
            return ConvertToUniqIdString(text);
        }
        
        public static string ConvertToUniqIdString(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            var uniqId = Convert.ToBase64String(plainTextBytes, 0, 16);
            return uniqId.Substring(0, 16);
        }
    }
}