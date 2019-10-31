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
            var input = "1234567890";
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

        #region ConvertToByteArray tests

        [TestMethod]
        public void ConvertBinary()
        {
            var input = "1010 1010 0011 0101";
            var actualResult = manager.ConvertToByteArray(input);
            var expectedResult = new byte[]
            {
                (byte)170,
                (byte)26
            };
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertDecimal()
        {
            var input = "‭61491‬";
            var actualResult = manager.ConvertToByteArray(input);
            var expectedResult = new byte[]
            {
                (byte)240,
                (byte)51
            };
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertHexadecimal()
        {
            var input = "‭ABCD‬";
            var actualResult = manager.ConvertToByteArray(input);
            var expectedResult = new byte[]
            {
                (byte)171,
                (byte)205
            };
            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

        #region GetOutputs tests

        [TestMethod]
        public void GetOutputsForBinary()
        {
            var input = "‭1111 0010 1010 1011‬ 1010 1110 0100 0011";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("11110010101010111010111001000011"‬, outputs.Binary);
            Assert.AreEqual("242 171 174 67"‬, outputs.Byte);
            Assert.AreEqual("62123 44611‬"‬, outputs.Integer16);
            Assert.AreEqual("4071337539‬"‬, outputs.Integer32);
        }

        [TestMethod]
        public void GetOutputsForDecimal()
        {
            var input = "997 997";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("11110011101001101101‬‬"‬, outputs.Binary);
            Assert.AreEqual("15 58 109"‬, outputs.Byte);
            Assert.AreEqual("‭15 14957‬‬"‬, outputs.Integer16);
            Assert.AreEqual("997997‬"‬, outputs.Integer32);
        }

        [TestMethod]
        public void GetOutputsForHexadecimal()
        {
            var input = "FE DCBA";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("1111 1110 1101 1100 1011 1010‬"‬, outputs.Binary);
            Assert.AreEqual("254 220 186"‬, outputs.Byte);
            Assert.AreEqual("‭254 56506‬"‬, outputs.Integer16);
            Assert.AreEqual("16702650‬"‬, outputs.Integer32);
        }

        #endregion
    }
}
