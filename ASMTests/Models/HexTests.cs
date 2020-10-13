using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Models.Tests
{
    [TestClass()]
    public class HexTests
    {
        [TestMethod()]
        public void HexTest()
        {
            
            //cases
            Hex[] firstNumber = { new Hex(10), new Hex("A"), new Hex(5) + new Hex(5), new Hex(-5) + new Hex(15) };
            foreach(Hex n in firstNumber)
            {
                Assert.IsTrue(n == 10);
            }

            Hex hex = new Hex(9);
            hex++;
            Assert.IsTrue(hex == 10);
            Assert.IsTrue(hex.ToString() == "000A");

            var t = new Hex(-1);
            Assert.IsTrue(t == -1);
            Assert.IsTrue(t.ToString() == "FFFF");
            t--;
            Assert.IsTrue(t == -2);
            Assert.IsTrue(t.ToString() == "FFFE");
        }
    }
}