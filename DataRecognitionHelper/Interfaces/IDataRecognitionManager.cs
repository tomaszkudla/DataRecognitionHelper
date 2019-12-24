using DataRecognitionHelper.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRecognitionHelper.Interfaces
{
    public interface IDataRecognitionManager
    {
        InputType GuessInputType(string input);
    }
}
