using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger32Rev2301Output : IOutput
    {
        public string Name => "UInteger32 Rev 2301";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes2301(bytes);
            return ByteArrayUtils.ByteArrayAsUInt32(bytesReversed);
        }
    }
}
