using DataRecognitionHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecognitionHelper.Inputs
{
    public class HexInput : IInput
    {
        public string Name => "Hexadecimal";

        public byte[] GetBytes(string input)
        {
            return Enumerable.Range(0, input.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(input.Substring(x, 2), 16))
                .Reverse()
                .ToArray();
        }
    }
}
