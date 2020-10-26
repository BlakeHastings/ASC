using ASM.Core;
using ASM.Opcode_Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ASM.Hardware_Components;
using ASM.Assembler.Assembler_Instructions;
using ASM.Assembler.Assembler_Instructions.Instructions;

namespace ASM.Assembler.Tests
{
    [TestClass()]
    public class AssemblerTests
    {
        [TestMethod()]
        public void TreatForProcessingTest()
        {
            List<InstructionsBase> supportedOpcodeInstructions = new List<InstructionsBase>();
            supportedOpcodeInstructions.Add(new HLT(new Machine()));
            supportedOpcodeInstructions.Add(new LDA(new Machine()));
            supportedOpcodeInstructions.Add(new STA(new Machine()));
            supportedOpcodeInstructions.Add(new ADD(new Machine()));
            supportedOpcodeInstructions.Add(new TCA(new Machine()));
            supportedOpcodeInstructions.Add(new BRU(new Machine()));
            supportedOpcodeInstructions.Add(new BIP(new Machine()));
            supportedOpcodeInstructions.Add(new BIN(new Machine()));
            supportedOpcodeInstructions.Add(new RWD(new Machine()));
            supportedOpcodeInstructions.Add(new WWD(new Machine()));
            supportedOpcodeInstructions.Add(new SHL(new Machine()));
            supportedOpcodeInstructions.Add(new SHR(new Machine()));
            supportedOpcodeInstructions.Add(new LDX(new Machine()));
            supportedOpcodeInstructions.Add(new STX(new Machine()));
            supportedOpcodeInstructions.Add(new TIX(new Machine()));
            supportedOpcodeInstructions.Add(new TDX(new Machine()));

            List<AssemblerInstruction> supportedAssemblerInstructions = new List<AssemblerInstruction>();
            
            


            Assembler assembler = new Assembler(supportedOpcodeInstructions);
            assembler.Assemble(@"C:\Users\Blake\OneDrive\School\Fall 2020\COMP 3410\ASC Software\dist\Broken Script\brokenScript.ASM");
            
        }
    }
}