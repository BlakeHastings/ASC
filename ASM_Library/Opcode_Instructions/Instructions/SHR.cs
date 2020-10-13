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

        public override void Invoke(Machine machine, Instruction instruction)
        {
            machine.acc.setValue(new Hex(machine.acc.HexValue >> 1));
            machine.memory.IncrementBuffer();
        }
    }
   
}
