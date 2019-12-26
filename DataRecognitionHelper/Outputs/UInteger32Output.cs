using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger32Output : IOutput
    {
        public string Name => "UInteger32";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo4Bytes(bytes);
            var result = new List<UInt32>();

            for (int i = 0; i < bytesNormalized.Length; i += 4)
            {
                var num = BitConverter.ToUInt32(bytesNormalized, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
