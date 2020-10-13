using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class BIP : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("6");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            if (machine.acc.HexValue > 0)
                machine.memory.BufferIndex = new Hex(instruction.AddressInt());
            else
                machine.memory.IncrementBuffer();
        }
    }
}
