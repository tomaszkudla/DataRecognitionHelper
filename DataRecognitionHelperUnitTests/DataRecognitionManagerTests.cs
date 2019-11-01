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

        #region ConvertToByteArray tests

        [TestMethod]
        public void ConvertBinary()
        {
            var input = "1010 1010 0011 0101";
            var actualResult = manager.ConvertToByteArray(input);
            var expectedResult = new byte[]
            {
                (byte)53,
                (byte)170,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertDecimal()
        {
            var input = "61491";
            var actualResult = manager.ConvertToByteArray(input);
            var expectedResult = new byte[]
            {
                (byte)51,
                (byte)240,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertHexadecimal()
        {
            var input = "ABCD";
            var actualResult = manager.ConvertToByteArray(input);
            var expectedResult = new byte[]
            {
                (byte)205,
                (byte)171,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        #endregion

        #region GetOutputs tests

        [TestMethod]
        public void GetOutputsForBinary()
        {
            var input = "1111 0010 1010 1011 1010 1110 0100 0011";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("11110010101010111010111001000011", outputs.Binary);
            CollectionAssert.AreEqual(new byte[] { 67, 174, 171, 242 }, outputs.Byte);
            CollectionAssert.AreEqual(new UInt16[] { 44611, 62123 }, outputs.Integer16);
            CollectionAssert.AreEqual(new UInt32[] { 4071337539 }, outputs.Integer32);
        }

        [TestMethod]
        public void GetOutputsForDecimal()
        {
            var input = "997 997";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("11110011101001101101", outputs.Binary);
            CollectionAssert.AreEqual(new byte[] { 109, 58, 15 }, outputs.Byte);
            CollectionAssert.AreEqual(new UInt16[] { 14957, 15 }, outputs.Integer16);
            CollectionAssert.AreEqual(new UInt32[] { 997997 }, outputs.Integer32);
        }

        [TestMethod]
        public void GetOutputsForHexadecimal()
        {
            var input = "FE DCBA";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("111111101101110010111010", outputs.Binary);
            CollectionAssert.AreEqual(new byte[] { 186, 220, 254 }, outputs.Byte);
            CollectionAssert.AreEqual(new UInt16[] { 56506, 254 }, outputs.Integer16);
            CollectionAssert.AreEqual(new UInt32[] { 16702650 }, outputs.Integer32);
        }

        [TestMethod]
        public void GetOutputsForHexadecimal2()
        {
            var input = "00FE DCBA";
            var outputs = manager.GetOutputs(input);

            Assert.AreEqual("111111101101110010111010", outputs.Binary);
            CollectionAssert.AreEqual(new byte[] { 186, 220, 254, 0 }, outputs.Byte);
            CollectionAssert.AreEqual(new UInt16[] { 56506, 254 }, outputs.Integer16);
            CollectionAssert.AreEqual(new UInt32[] { 16702650 }, outputs.Integer32);
        }

        #endregion
    }
}
