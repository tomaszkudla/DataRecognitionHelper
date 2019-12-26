using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelper.Outputs
{
    public class UInteger32Output : IOutput
    {
        public string Name => "UInteger32";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var bytesNormalized = ByteArrayUtils.NormalizeTo4Bytes(bytes);
            return ByteArrayUtils.ByteArrayAsUInt32(bytesNormalized);
        }
    }
}
