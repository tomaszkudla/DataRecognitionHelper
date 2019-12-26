using System;
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

        public static byte[] NormalizeTo2Bytes(byte[] bytes)
        {
            if (bytes.Length % 2 != 0)
            {
                return bytes.Concat(new byte[] { (byte)0 }).ToArray();
            }

            return bytes;
        }

        public static byte[] NormalizeTo4Bytes(byte[] bytes)
        {
            var remainder = bytes.Length % 4;

            if (remainder > 0)
            {
                var missingbytes = new byte[0];
                for (int i = 0; i < 4 - remainder; i++)
                {
                    missingbytes = missingbytes.Concat(new byte[] { (byte)0 }).ToArray();
                }

                return bytes.Concat(missingbytes).ToArray();
            }

            return bytes;
        }

        public static byte[] ReverseBytes10(byte[] bytes)
        {
            var bytesNormalized = NormalizeTo2Bytes(bytes);
            var bytesNew = new List<byte>();

            for (int i = 1; i < bytesNormalized.Length; i += 2)
            {
                bytesNew.Add(bytesNormalized[i]);
                bytesNew.Add(bytesNormalized[i - 1]);
            }

            return bytesNew.ToArray();
        }

        public static byte[] ReverseBytes3210(byte[] bytes)
        {
            var bytesNormalized = NormalizeTo4Bytes(bytes); 
            var bytesNew = new List<byte>();

            for (int i = 3; i < bytesNormalized.Length; i += 4)
            {
                bytesNew.Add(bytesNormalized[i]);
                bytesNew.Add(bytesNormalized[i - 1]);
                bytesNew.Add(bytesNormalized[i - 2]);
                bytesNew.Add(bytesNormalized[i - 3]);
            }

            return bytesNew.ToArray();
        }

        public static byte[] ReverseBytes1032(byte[] bytes)
        {
            var bytesNormalized = NormalizeTo4Bytes(bytes);
            var bytesNew = new List<byte>();

            for (int i = 3; i < bytesNormalized.Length; i += 4)
            {
                bytesNew.Add(bytesNormalized[i - 2]);
                bytesNew.Add(bytesNormalized[i - 3]);
                bytesNew.Add(bytesNormalized[i - 0]);
                bytesNew.Add(bytesNormalized[i - 1]);
            }

            return bytesNew.ToArray();
        }

        public static byte[] ReverseBytes2301(byte[] bytes)
        {
            var bytesNormalized = NormalizeTo4Bytes(bytes);
            var bytesNew = new List<byte>();

            for (int i = 3; i < bytesNormalized.Length; i += 4)
            {
                bytesNew.Add(bytesNormalized[i - 1]);
                bytesNew.Add(bytesNormalized[i - 0]);
                bytesNew.Add(bytesNormalized[i - 3]);
                bytesNew.Add(bytesNormalized[i - 2]);
            }

            return bytesNew.ToArray();
        }

        public static string ByteArrayAsInt16(byte[] bytes)
        {
            var result = new List<Int16>();

            for (int i = 0; i < bytes.Length; i += 2)
            {
                var num = BitConverter.ToInt16(bytes, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }

        public static string ByteArrayAsUInt16(byte[] bytes)
        {
            var result = new List<UInt16>();

            for (int i = 0; i < bytes.Length; i += 2)
            {
                var num = BitConverter.ToUInt16(bytes, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }

        public static string ByteArrayAsInt32(byte[] bytes)
        {
            var result = new List<Int32>();

            for (int i = 0; i < bytes.Length; i += 4)
            {
                var num = BitConverter.ToInt32(bytes, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }

        public static string ByteArrayAsUInt32(byte[] bytes)
        {
            var result = new List<UInt32>();

            for (int i = 0; i < bytes.Length; i += 4)
            {
                var num = BitConverter.ToUInt32(bytes, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
