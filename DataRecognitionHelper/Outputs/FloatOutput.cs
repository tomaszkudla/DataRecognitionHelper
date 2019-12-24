using DataRecognitionHelper.Interfaces;
using System;

namespace DataRecognitionHelper.Outputs
{
    public class FloatOutput : IOutput
    {
        public string Name => "Float";

        public string GetOutput(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
