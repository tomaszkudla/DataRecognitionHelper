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
    public class Integer16OutputTests
    {
        IOutput output = new Integer16Output();
        IInput binInput = new BinInput();
        IInput decInput = new DecInput();
        IInput hexInput = new HexInput();

        [TestMethod]
        public void ConvertBinaryToInteger16()
        {
            var data = "1111 0010 1010 1011 1010 1110 0100 0011";
            data = StringUtils.EscapeSpaces(data);
            var bytes = binInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("44611 62123", result);
        }

        [TestMethod]
        public void ConvertDecToInteger16()
        {
            var data = "997 997";
            data = StringUtils.EscapeSpaces(data);
            var bytes = decInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("14957 15", result);
        }

        [TestMethod]
        public void ConvertHexToInteger16()
        {
            var data = "FE DCBA";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("56506 254", result);
        }

        [TestMethod]
        public void ConvertHexToInteger16_2()
        {
            var data = "00FE DCBA";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("56506 254", result);
        }
    }
}
