using DataRecognitionHelper.Data;
using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Outputs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecognitionHelper.Implementations
{
    public class DataRecognitionManager : IDataRecognitionManager
    {
        public List<IOutput> GetOutputs()
        {
            return new List<IOutput>()
            {
                new BinaryOutput(),
                new ByteOutput(),
                new Integer16Output(),
                new Integer32Output()
            };
        }

        public IInput GuessInputType(string input)
        {
            input = EscapeSpaces(input);

            var binaries = new char[] { '0', '1' };
            if (input.All(c => binaries.Contains(c)))
            {
                return new BinInput();
            }
            else if (input.All(char.IsDigit))
            {
                return new DecInput();
            }
            else if (input.ToLower().All(c => char.IsDigit(c) || new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }.Contains(c)))
            {
                return new HexInput();
            }

            return new TextInput();
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
