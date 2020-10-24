using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Models.Tests
{
    [TestClass()]
    public class InstructionTests
    {
        [TestMethod()]
        public void InstructionTest()
        {
            AssembledInstruction[] instructions = {
                new AssembledInstruction("6008"),
                new AssembledInstruction("6008"),
                new AssembledInstruction("0110000000001000")
            };

            foreach (AssembledInstruction instruction in instructions)
            {
                Assert.IsTrue(instruction.Opcode == "0110");
                Assert.IsTrue(instruction.Extension_Bit == "0");
                Assert.IsTrue(instruction.Indirect_Flag == "0");
                Assert.IsTrue(instruction.Index_Flag == "00");
                Assert.IsTrue(instruction.Address == "00001000");
            }

            instructions = new AssembledInstruction[]{
                new AssembledInstruction("C109"),
                new AssembledInstruction("1100000100001001")
            };

            foreach (AssembledInstruction instruction in instructions)
            {
                Assert.IsTrue(instruction.Opcode == "1100");
                Assert.IsTrue(instruction.Extension_Bit == "0");
                Assert.IsTrue(instruction.Indirect_Flag == "0");
                Assert.IsTrue(instruction.Index_Flag == "01");
                Assert.IsTrue(instruction.Address == "00001001");
            }
        }
    }
}