using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class Integer32Rev1032Output : IOutput
    {
        public string Name => "Integer32 Rev 1032";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes1032(bytes);
            return ByteArrayUtils.ByteArrayAsInt32(bytesReversed);
        }
    }
}
