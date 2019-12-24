using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecognitionHelper.Utils
{
    public static class StringUtils
    {
        public static string EscapeSpaces(string input)
        {
            if (input == null)
            { 
                return null; 
            }

            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public static byte[] TrimByteArray(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            return bytes.Reverse().SkipWhile(b => b == 0).Reverse().ToArray();
        }

        public static string EnumerableToString<T>(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return null;
            }

            var sb = new StringBuilder();
            var count = enumerable.Count();

            for (int i = 0; i < count; i++)
            {
                sb.Append(enumerable.ElementAt(i).ToString());

                if (i + 1 != count)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}
