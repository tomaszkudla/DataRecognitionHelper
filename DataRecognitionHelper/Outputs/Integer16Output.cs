using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var bytesCopy = new byte[bytes.Length];
            bytes.CopyTo(bytesCopy, 0);
            var result = new List<UInt16>();

            if (bytesCopy.Length % 2 != 0)
            {
                bytesCopy = bytesCopy.Concat(new byte[] { (byte)0 }).ToArray();
            }

            for (int i = 0; i < bytesCopy.Length; i += 2)
            {
                var integer16 = BitConverter.ToUInt16(bytesCopy, i);
                result.Add(integer16);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
