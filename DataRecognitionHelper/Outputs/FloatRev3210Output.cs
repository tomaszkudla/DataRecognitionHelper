using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class FloatRev3210Output : IOutput
    {
        public string Name => "Float Rev 3210";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesReversed = ByteArrayUtils.ReverseBytes3210(bytes);
            return ByteArrayUtils.ByteArrayAsFloat(bytesReversed);
        }
    }
}
