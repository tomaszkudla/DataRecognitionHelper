using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;

namespace DataRecognitionHelper.Outputs
{
    public class Integer16Output : IOutput
    {
        public string Name => "Integer16";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo2Bytes(bytes);
            var result = new List<Int16>();

            for (int i = 0; i < bytesNormalized.Length; i += 2)
            {
                var num = BitConverter.ToInt16(bytesNormalized, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
