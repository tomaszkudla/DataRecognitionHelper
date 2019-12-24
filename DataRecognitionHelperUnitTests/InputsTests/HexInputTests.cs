using DataRecognitionHelper.Inputs;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRecognitionHelperUnitTests.InputsTests
{
    [TestClass]
    public class HexInputTests
    {
        IInput input = new HexInput();

        [TestMethod]
        public void ConvertHexadecimal()
        {
            var data = "ABCD";
            data = StringUtils.EscapeSpaces(data);
            var actualResult = input.GetBytes(data);
            var expectedResult = new byte[]
            {
                (byte)205,
                (byte)171,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
