using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System;
using System.Text;

namespace DataRecognitionHelper.Inputs
{
    public class ASCIIInput : IInput
    {
        public string Name => "ASCII";

        public byte[] GetBytes(string input)
        {
            var bytes = Encoding.ASCII.GetBytes(input);
            return StringUtils.TrimByteArray(bytes);
        }

        public bool IsApplicable(string input)
        {
            return true;
        }
    }
}
