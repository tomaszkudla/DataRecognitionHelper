using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class Integer16Output : IOutput
    {
        public string Name => "Integer16";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo2Bytes(bytes);
            return ByteArrayUtils.ByteArrayAsInt16(bytesNormalized);
        }
    }
}
