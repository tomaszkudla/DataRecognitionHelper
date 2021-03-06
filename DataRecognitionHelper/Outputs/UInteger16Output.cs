﻿using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

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
            return ByteArrayUtils.ByteArrayAsUInt16(bytesNormalized);
        }
    }
}
