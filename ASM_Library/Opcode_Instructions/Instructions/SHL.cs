using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class SHL : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("A");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            machine.acc.setValue(new Hex( machine.acc.HexValue << 1));
            machine.memory.IncrementBuffer();
        }
    }
}
