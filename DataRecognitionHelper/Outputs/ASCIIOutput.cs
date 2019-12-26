using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using System.Text;

namespace DataRecognitionHelper.Outputs
{
    public class ASCIIOutput : IOutput
    {
        public string Name => "ASCII";

        public string GetOutput(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            return Encoding.ASCII.GetString(bytes);
        }
    }
}
