using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRecognitionHelper.Outputs
{
    public class ByteOutput : IOutput
    {
        public string Name => "Byte";

        public string GetOutput(byte[] bytes)
        {
            return StringUtils.EnumerableToString(bytes);
        }
    }
}
