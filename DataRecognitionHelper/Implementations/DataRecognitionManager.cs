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
        public byte[] ConvertToByteArray(string input, InputType inputType = InputType.Auto)
        {
            if (inputType == InputType.Auto)
            {
                inputType = GuessInputType(input);
            }

            input = EscapeSpaces(input);

            switch (inputType)
            {
                case InputType.Bin:
                    {
                        var bools = input.Select(c => c == '0' ? false : c == '1' ? true : false).Reverse().ToArray();
                        var bitArray = new BitArray(bools);
                        var bitArrayLength = bitArray.Length;
                        var length = bitArrayLength % 4 == 0 ? bitArrayLength / 4 : bitArrayLength / 4 + 1;
                        byte[] bytes = new byte[length];
                        bitArray.CopyTo(bytes, 0);
                        return TrimByteArray(bytes);
                    }
                case InputType.Dec:
                    {
                        if (UInt64.TryParse(input, out var result64))
                        {
                            var bytes = BitConverter.GetBytes(result64);
                            return TrimByteArray(bytes);
                        }

                        break;
                    }
                case InputType.Hex:
                    {
                        return Enumerable.Range(0, input.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(input.Substring(x, 2), 16))
                            .Reverse()
                            .ToArray();
                    }
            }

            return new byte[0];
        }

        public Outputs GetOutputs(string input, InputType inputType = InputType.Auto)
        {
            var bytes = ConvertToByteArray(input);
            var outputs = new Outputs();

            outputs.Binary = GetBinaryOutput(bytes);
            outputs.Byte = bytes;
            outputs.Integer16 = GetUInt16Output(bytes);
            outputs.Integer32 = GetUInt32Output(bytes);
            return outputs;
        }

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

        private string GetBinaryOutput(byte[] bytes)
        {
            var bits = new BitArray(bytes);

            var sb = new StringBuilder();

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString().TrimStart(new Char[] { '0' });
        }

        private UInt16[] GetUInt16Output(byte[] bytes)
        {
            var bytesCopy = new byte[bytes.Length];
            bytes.CopyTo(bytesCopy, 0);
            var result = new List<UInt16>();

            if (bytesCopy.Length % 2 != 0)
            {
                bytesCopy = bytesCopy.Concat(new byte[] { (byte)0 }).ToArray();
            }

            for (int i = 0; i < bytesCopy.Length; i+=2)
            {
                var integer16 = BitConverter.ToUInt16(bytesCopy, i);
                result.Add(integer16);
            }

            return result.ToArray();
        }

        private UInt32[] GetUInt32Output(byte[] bytes)
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

            return result.ToArray();
        }
    }
}
