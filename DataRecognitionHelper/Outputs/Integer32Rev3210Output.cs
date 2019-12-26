using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class Integer32Rev3210Output : IOutput
    {
        public string Name => "Integer32 Rev 3210";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes3210(bytes);
            return ByteArrayUtils.ByteArrayAsInt32(bytesReversed);
        }
    }
}
