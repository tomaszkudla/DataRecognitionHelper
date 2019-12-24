using System;
using System.Collections.Generic;
using System.Text;

namespace DataRecognitionHelper.Interfaces
{
    public interface IInput
    {
        string Name { get; }
        byte[] GetBytes(string input);
    }
}
