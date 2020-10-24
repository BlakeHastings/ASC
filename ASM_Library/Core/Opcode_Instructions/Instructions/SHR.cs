using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class SHR : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("B");

        public override string MNEMONIC { get; } = "SHR";

        public SHR(Machine machine) : base(machine) { }
        public override void Invoke()
        {
            machine.acc.setValue(new Hex(machine.acc.HexValue >> 1));
            machine.memory.IncrementBuffer();
        }
    }
   
}
