using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Outputs;
using DataRecognitionHelper.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataRecognitionHelperUnitTests.OutputsTests
{
    [TestClass]
    public class FloatOutputTests
    {
        IOutput output = new FloatOutput();
        IInput hexInput = new HexInput();

        [TestMethod]
        public void ConvertBinaryToBinary()
        {
            var data = "41 1F 85 1F";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("9.97", result);
        }
    }
}
