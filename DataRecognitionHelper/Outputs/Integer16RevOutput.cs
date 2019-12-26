using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class Integer16RevOutput : IOutput
    {
        public string Name => "Integer16 Rev";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes10(bytes);
            return ByteArrayUtils.ByteArrayAsInt16(bytesReversed);
        }
    }
}
