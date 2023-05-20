namespace ShortLink.Common.Helpers
{
    public static class ShortenerHelpers
    {
        const string base62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static long Base62ToBase10(string s)
        {
            long n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                n = n * 62 + Char2Int(s[i]);
            }

            return n;
        }

        public static int Char2Int(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            if (c >= 'a' && c <= 'z')
            {
                return c - 'a' + 10;
            }

            if (c >= 'A' && c <= 'Z')
            {
                return c - 'A' + 36;
            }

            return -1;
        }

        public static string Base10ToBase62(long n)
        {
            string result = "";
            do
            {
                int ind = (int) (n % 62);
                result = base62[ind] + result;
                n /= 62;
            } while (n != 0);

            while (result.Length < 7)
            {
                result = "0" + result;
            }

            return result;
        }
    }
}