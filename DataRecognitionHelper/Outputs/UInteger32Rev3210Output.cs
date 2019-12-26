using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger32Rev3210Output : IOutput
    {
        public string Name => "UInteger32 Rev 3210";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes3210(bytes);
            return ByteArrayUtils.ByteArrayAsUInt32(bytesReversed);
        }
    }
}
