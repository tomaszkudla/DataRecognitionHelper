using System;
using System.Collections.Generic;
using System.Text;

namespace DataRecognitionHelper.Interfaces
{
    public interface IOutput
    {
        string Name { get; }
        string GetOutput(byte[] bytes);
    }
}
