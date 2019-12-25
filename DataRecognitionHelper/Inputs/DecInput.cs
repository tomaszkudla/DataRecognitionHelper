using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Linq;

namespace DataRecognitionHelper.Inputs
{
    public class DecInput : IInput
    {
        public string Name => "Decimal";

        public byte[] GetBytes(string input)
        {
            if (Int64.TryParse(input, out var result64))
            {
                var bytes = BitConverter.GetBytes(result64);

                if (result64 < 0)
                {
                    return ByteArrayUtils.TrimByteArrayForNegative(bytes);
                }

                return ByteArrayUtils.TrimByteArray(bytes);
            }

            return null;
        }

        public bool IsApplicable(string input)
        {
            return Int64.TryParse(input, out _);
        }
    }
}
