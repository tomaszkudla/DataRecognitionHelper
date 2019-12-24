using DataRecognitionHelper.Interfaces;
using System;
using System.Linq;

namespace DataRecognitionHelper.Inputs
{
    public class HexInput : IInput
    {
        public string Name => "Hexadecimal";

        public byte[] GetBytes(string input)
        {
            if (!IsApplicable(input))
            {
                return null;
            }

            return Enumerable.Range(0, input.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(input.Substring(x, 2), 16))
                .Reverse()
                .ToArray();
        }

        public bool IsApplicable(string input)
        {
            return input.ToLower().All(c => char.IsDigit(c) || new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }.Contains(c));
        }
    }
}
