using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class ByteOutput : IOutput
    {
        public string Name => "Byte";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            return StringUtils.EnumerableToString(bytes);
        }
    }
}
