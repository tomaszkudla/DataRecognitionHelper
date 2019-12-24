using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataRecognitionHelper.Implementations;
using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Utils;

namespace DataRecognitionHelperUnitTests
{
    [TestClass]
    public class DataRecognitionManagerTests
    {
        private DataRecognitionManager manager;
        public DataRecognitionManagerTests()
        {
            manager = new DataRecognitionManager();
        }

        [TestMethod]
        public void GuessBinaryInput()
        {
            var input = "1010 1000 1111 0101";
            input = StringUtils.EscapeSpaces(input);
            var result = manager.GuessInputType(input);
            Assert.IsInstanceOfType(result, typeof(BinInput));
        }

        [TestMethod]
        public void GuessDecimalInput()
        {
            var input = "1 234 567 890";
            input = StringUtils.EscapeSpaces(input);
            var result = manager.GuessInputType(input);
            Assert.IsInstanceOfType(result, typeof(DecInput));
        }

        [TestMethod]
        public void GuessHexadecimalInput()
        {
            var input = "FFFF FFFF";
            input = StringUtils.EscapeSpaces(input);
            var result = manager.GuessInputType(input);
            Assert.IsInstanceOfType(result, typeof(HexInput));
        }
    }
}
