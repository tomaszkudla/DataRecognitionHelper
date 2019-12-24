using DataRecognitionHelper.Data;
using DataRecognitionHelper.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecognitionHelper.Implementations
{
    public class DataRecognitionManager : IDataRecognitionManager
    {
        public InputType GuessInputType(string input)
        {
            input = EscapeSpaces(input);

            var binaries = new char[] { '0', '1' };
            if (input.All(c => binaries.Contains(c)))
            {
                return InputType.Bin;
            }
            else if (input.All(char.IsDigit))
            {
                return InputType.Dec;
            }
            else if (input.ToLower().All(c => char.IsDigit(c) || new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }.Contains(c)))
            {
                return InputType.Hex;
            }

            return InputType.Text;
        }

        private string EscapeSpaces(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        private byte[] TrimByteArray(byte[] bytes)
        {
            return bytes.Reverse().SkipWhile(b => b == 0).Reverse().ToArray();
        }
    }
}
