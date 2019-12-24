using DataRecognitionHelper.Interfaces;
using System;

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

            throw new NotImplementedException();
        }
    }
}
