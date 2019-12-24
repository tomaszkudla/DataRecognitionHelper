using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataRecognitionHelperUnitTests.InputsTests
{
    [TestClass]
    public class DecInputTests
    {
        IInput input = new DecInput();

        [TestMethod]
        public void ConvertDecimal()
        {
            var data = "61491";
            data = StringUtils.EscapeSpaces(data);
            var actualResult = input.GetBytes(data);
            var expectedResult = new byte[]
            {
                (byte)51,
                (byte)240,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
