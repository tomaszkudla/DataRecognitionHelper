using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger16RevOutput : IOutput
    {
        public string Name => "UInteger16 Rev";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes10(bytes);
            var result = new List<UInt16>();

            for (int i = 0; i < bytesReversed.Length; i += 2)
            {
                var num = BitConverter.ToUInt16(bytesReversed, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
