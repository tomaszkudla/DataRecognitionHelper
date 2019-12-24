using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecognitionHelper.Inputs
{
    public class BinInput : IInput
    {
        public string Name => "Binary";

        public byte[] GetBytes(string input)
        {
            var bools = input.Select(c => c == '0' ? false : c == '1' ? true : false).Reverse().ToArray();
            var bitArray = new BitArray(bools);
            var bitArrayLength = bitArray.Length;
            var length = bitArrayLength % 4 == 0 ? bitArrayLength / 4 : bitArrayLength / 4 + 1;
            byte[] bytes = new byte[length];
            bitArray.CopyTo(bytes, 0);
            return StringUtils.TrimByteArray(bytes);
        }
    }
}
