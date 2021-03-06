﻿using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class FloatOutput : IOutput
    {
        public string Name => "Float";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo4Bytes(bytes);
            return ByteArrayUtils.ByteArrayAsFloat(bytesNormalized);
        }
    }
}
