using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Outputs;
using DataRecognitionHelper.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataRecognitionHelperUnitTests.OutputsTests
{
    [TestClass]
    public class UInteger32OutputTests
    {
        IOutput output = new UInteger32Output();
        IInput binInput = new BinInput();
        IInput decInput = new DecInput();
        IInput hexInput = new HexInput();

        [TestMethod]
        public void ConvertBinaryToUInteger32()
        {
            var data = "1111 0010 1010 1011 1010 1110 0100 0011";
            data = StringUtils.EscapeSpaces(data);
            var bytes = binInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("4071337539", result);


        }

        [TestMethod]
        public void ConvertDecToUInteger32()
        {
            var data = "997 997";
            data = StringUtils.EscapeSpaces(data);
            var bytes = decInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("997997", result);

        }

        [TestMethod]
        public void ConvertHexToUInteger32()
        {
            var data = "FE DCBA";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("16702650", result);
        }

        [TestMethod]
        public void ConvertHexToUInteger32_2()
        {
            var data = "00FE DCBA";
            data = StringUtils.EscapeSpaces(data);
            var bytes = hexInput.GetBytes(data);
            var result = output.GetOutput(bytes);

            Assert.AreEqual("16702650", result);
        }
    }
}
