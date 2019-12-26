using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger16Output : IOutput
    {
        public string Name => "UInteger16";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo2Bytes(bytes);
            var result = new List<UInt16>();

            for (int i = 0; i < bytesNormalized.Length; i += 2)
            {
                var num = BitConverter.ToUInt16(bytesNormalized, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
