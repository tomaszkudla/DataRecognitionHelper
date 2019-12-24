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
    public class BinInputTests
    {
        IInput input = new BinInput();

        [TestMethod]
        public void ConvertBinary()
        {
            var data = "1010 1010 0011 0101";
            data = StringUtils.EscapeSpaces(data);
            var actualResult = input.GetBytes(data);
            var expectedResult = new byte[]
            {
                (byte)53,
                (byte)170,
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
