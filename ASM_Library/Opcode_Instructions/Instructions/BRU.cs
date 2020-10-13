using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class BRU : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("5");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            machine.memory.BufferIndex = new Hex(instruction.AddressInt());
        }
    }
}
