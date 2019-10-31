using DataRecognitionHelper.Data;
using DataRecognitionHelper.Interfaces;
using System;

namespace DataRecognitionHelper.Implementations
{
    public class DataRecognitionManager : IDataRecognitionManager
    {
        public byte[] ConvertToByteArray(string input, InputType inputType = InputType.Auto)
        {
            throw new NotImplementedException();
        }

        public Outputs GetOutputs(string input, InputType inputType = InputType.Auto)
        {
            throw new NotImplementedException();
        }

        public InputType GuessInputType(string input)
        {
            throw new NotImplementedException();
        }

    }
}
