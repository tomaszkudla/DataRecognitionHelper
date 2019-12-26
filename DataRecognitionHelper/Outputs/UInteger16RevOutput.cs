using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger16RevOutput : IOutput
    {
        public string Name => "UInteger16 Rev";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes10(bytes);
            return ByteArrayUtils.ByteArrayAsUInt16(bytesReversed);
        }
    }
}
