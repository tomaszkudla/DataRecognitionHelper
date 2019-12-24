using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataRecognitionHelper.Data;
using DataRecognitionHelper.Implementations;

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

        #region GuessImputType tests

        [TestMethod]
        public void GuessBinaryInput()
        {
            var input = "1010 1000 1111 0101";
            var actualResult = manager.GuessInputType(input);
            Assert.AreEqual(InputType.Bin, actualResult);
        }

        [TestMethod]
        public void GuessDecimalInput()
        {
            var input = "1 234 567 890";
            var actualResult = manager.GuessInputType(input);
            Assert.AreEqual(InputType.Dec, actualResult);
        }

        [TestMethod]
        public void GuessHexadecimalInput()
        {
            var input = "FFFF FFFF";
            var actualResult = manager.GuessInputType(input);
            Assert.AreEqual(InputType.Hex, actualResult);
        }

        [TestMethod]
        public void GuessTextInput()
        {
            var input = "Hello world!";
            var actualResult = manager.GuessInputType(input);
            Assert.AreEqual(InputType.Text, actualResult);
        }
        #endregion
    }
}
