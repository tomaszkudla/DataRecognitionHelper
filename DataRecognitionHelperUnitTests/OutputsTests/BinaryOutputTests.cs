using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Outputs;
using DataRecognitionHelper.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRecognitionHelperUnitTests.OutputsTests
{
    [TestClass]
    public class BinaryOutputTests
    {
        IOutput output = new BinaryOutput();
        IInput binInput = new BinInput();
        IInput decInput = new DecInput();
        IInput hexInput = new HexInput();

        [TestMethod]
        public void ConvertBinaryToBinary()
        {
            var data = "1111 0010 1010 1011 1010 1110 0100 0011";
            data = StringUtils.EscapeSpaces(data);
            var bytes = binInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("11110010101010111010111001000011", result);
        }

        [TestMethod]
        public void ConvertDecToBinary()
        {
            var data = "997 997";
            data = StringUtils.EscapeSpaces(data);
            var bytes = decInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("11110011101001101101", result);
        }

        [TestMethod]
        public void ConvertHexToBinary()
        {
            var data = "FE DCBA";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("111111101101110010111010", result);
        }

        [TestMethod]
        public void ConvertHexToBinary2()
        {
            var data = "00FE DCBA";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("111111101101110010111010", result);
        }
    }
}
