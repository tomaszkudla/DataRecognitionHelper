using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecognitionHelper.Utils
{
    public static class ByteArrayUtils
    {
        public static byte[] TrimByteArray(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            return bytes.Reverse().SkipWhile(b => b == 0).Reverse().ToArray();
        }

        public static byte[] TrimByteArrayForNegative(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var firstbyte = bytes.ElementAt(0);
            var remainingBytes = bytes.Skip(1).Reverse().SkipWhile(b => b == 255).Reverse().ToList();
            remainingBytes.Insert(0, firstbyte);
            return remainingBytes.ToArray();
        }
    }
}
