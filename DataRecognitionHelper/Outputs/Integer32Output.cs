using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class Integer32Output : IOutput
    {
        public string Name => "Integer32";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo4Bytes(bytes);
            return ByteArrayUtils.ByteArrayAsInt32(bytesNormalized);
        }
    }
}
