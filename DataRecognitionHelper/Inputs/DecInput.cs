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
            if (!IsApplicable(input))
            {
                return null;
            }

            if (UInt64.TryParse(input, out var result64))
            {
                var bytes = BitConverter.GetBytes(result64);
                return StringUtils.TrimByteArray(bytes);
            }

            return null;
        }

        public bool IsApplicable(string input)
        {
            return input.All(char.IsDigit);
        }
    }
}
