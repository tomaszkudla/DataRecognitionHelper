using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Outputs;
using DataRecognitionHelper.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DataRecognitionHelper.Implementations
{
    public class DataRecognitionManager : IDataRecognitionManager
    {
        public List<IInput> GetInputs()
        {
            return new List<IInput>()
            {
                new BinInput(),
                new DecInput(),
                new HexInput(),
                new ASCIIInput(),
            };
        }

        public IInput GuessInputType(string input)
        {
            return GetInputs().FirstOrDefault(i => i.IsApplicable(input));
        }

        public List<IOutput> GetOutputs()
        {
            return new List<IOutput>()
            {
                new BinaryOutput(),
                new ByteOutput(),
                new UInteger16Output(),
                new UInteger16RevOutput(),
                new Integer16Output(),
                new Integer16RevOutput(),
                new Integer32Output(),
                new UInteger32Output(),
                new UInteger32Rev3210Output(),
                new UInteger32Rev2301Output(),
                new UInteger32Rev1032Output(),
                new Integer32Output(),
                new Integer32Rev3210Output(),
                new Integer32Rev2301Output(),
                new Integer32Rev1032Output(),
                new FloatOutput(),
                new ASCIIOutput(),
            };
        }
    }
}
