using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System.Collections;
using System.Linq;

namespace DataRecognitionHelper.Inputs
{
    public class BinInput : IInput
    {
        public string Name => "Binary";

        public byte[] GetBytes(string input)
        {
            if (!IsApplicable(input))
            {
                return null;
            }

            var bools = input.Select(c => c == '0' ? false : c == '1' ? true : false).Reverse().ToArray();
            var bitArray = new BitArray(bools);
            var bitArrayLength = bitArray.Length;
            var length = bitArrayLength % 4 == 0 ? bitArrayLength / 4 : bitArrayLength / 4 + 1;
            byte[] bytes = new byte[length];
            bitArray.CopyTo(bytes, 0);
            return ByteArrayUtils.TrimByteArray(bytes);
        }

        public bool IsApplicable(string input)
        {
            var binaries = new char[] { '0', '1' };
            return input.All(c => binaries.Contains(c));
        }
    }
}
