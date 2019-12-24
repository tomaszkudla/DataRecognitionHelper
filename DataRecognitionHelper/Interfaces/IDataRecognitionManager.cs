using System.Collections.Generic;

namespace DataRecognitionHelper.Interfaces
{
    public interface IDataRecognitionManager
    {
        List<IInput> GetInputs();
        IInput GuessInputType(string input);
        List<IOutput> GetOutputs();
    }
}
