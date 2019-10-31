using DataRecognitionHelper.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRecognitionHelper.Interfaces
{
    public interface IDataRecognitionManager
    {
        InputType GuessInputType(string input);
        byte[] ConvertToByteArray(string input, InputType inputType = InputType.Auto);
        Outputs GetOutputs(string input, InputType inputType = InputType.Auto);
    }
}
