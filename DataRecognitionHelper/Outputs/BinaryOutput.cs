using DataRecognitionHelper.Interfaces;
using System;
using System.Collections;
using System.Text;

namespace DataRecognitionHelper.Outputs
{
    public class BinaryOutput : IOutput
    {
        public string Name => "Binary"; 

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bits = new BitArray(bytes);

            var sb = new StringBuilder();

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            var result = sb.ToString().TrimStart(new Char[] { '0' });

            if (string.IsNullOrEmpty(result))
            {
                result = "0";
            }

            return result;
        }
    }
}
