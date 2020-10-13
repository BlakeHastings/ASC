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
            Instruction[] instructions = {
                new Instruction("6008"),
                new Instruction("6008"),
                new Instruction("0110000000001000")
            };

            foreach (Instruction instruction in instructions)
            {
                Assert.IsTrue(instruction.Opcode == "0110");
                Assert.IsTrue(instruction.Extension_Bit == "0");
                Assert.IsTrue(instruction.Indirect_Flag == "0");
                Assert.IsTrue(instruction.Index_Flag == "00");
                Assert.IsTrue(instruction.Address == "00001000");
            }

            instructions = new Instruction[]{
                new Instruction("C109"),
                new Instruction("1100000100001001")
            };

            foreach (Instruction instruction in instructions)
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