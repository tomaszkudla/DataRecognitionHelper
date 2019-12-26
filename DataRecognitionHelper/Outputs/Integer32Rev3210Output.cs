using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;

namespace DataRecognitionHelper.Outputs
{
    public class Integer32Rev3210Output : IOutput
    {
        public string Name => "Integer32 Rev 3210";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.ReverseBytes3210(bytes);
            var result = new List<Int32>();

            for (int i = 0; i < bytesNormalized.Length; i += 4)
            {
                var num = BitConverter.ToInt32(bytesNormalized, i);
                result.Add(num);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
