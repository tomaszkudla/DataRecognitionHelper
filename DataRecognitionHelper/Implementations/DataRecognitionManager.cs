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
                new TextInput()
            };
        }

        public IInput GuessInputType(string input)
        {
            input = StringUtils.EscapeSpaces(input);
            return GetInputs().First(i => i.IsApplicable(input));
        }

        public List<IOutput> GetOutputs()
        {
            return new List<IOutput>()
            {
                new BinaryOutput(),
                new ByteOutput(),
                new Integer16Output(),
                new Integer32Output()
            };
        }
    }
}
