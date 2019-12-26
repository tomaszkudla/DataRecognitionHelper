using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;

namespace DataRecognitionHelper.Outputs
{
    public class Integer16RevOutput : IOutput
    {
        public string Name => "Integer16 Rev";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes10(bytes);
            var result = new List<Int16>();

            for (int i = 0; i < bytesReversed.Length; i += 2)
            {
                var num = BitConverter.ToInt16(bytesReversed, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
