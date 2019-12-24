using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataRecognitionHelper.Outputs
{
    public class Integer32Output : IOutput
    {
        public string Name => "Integer32";

        public string GetOutput(byte[] bytes)
        {
            var bytesCopy = new byte[bytes.Length];
            bytes.CopyTo(bytesCopy, 0);
            var result = new List<UInt32>();

            var remainder = bytesCopy.Length % 4;

            if (remainder > 0)
            {
                var missingbytes = new byte[0];
                for (int i = 0; i < 4 - remainder; i++)
                {
                    missingbytes = missingbytes.Concat(new byte[] { (byte)0 }).ToArray();
                }

                bytesCopy = bytesCopy.Concat(missingbytes).ToArray();
            }

            for (int i = 0; i < bytesCopy.Length; i += 4)
            {
                var integer32 = BitConverter.ToUInt32(bytesCopy, i);
                result.Add(integer32);
            }

            return StringUtils.EnumerableToString(result);
        }
    }
}
