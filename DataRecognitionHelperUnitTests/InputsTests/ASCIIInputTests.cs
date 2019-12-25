using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataRecognitionHelperUnitTests.InputsTests
{
    [TestClass]
    public class ASCIIInputTests
    {
        IInput input = new ASCIIInput();

        [TestMethod]
        public void ConvertASCII()
        {
            var data = "Hello";
            data = StringUtils.EscapeSpaces(data);
            var actualResult = input.GetBytes(data);
            var expectedResult = new byte[]
            {
                (byte)72,
                (byte)101,
                (byte)108,
                (byte)108,
                (byte)111,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
