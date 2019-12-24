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
