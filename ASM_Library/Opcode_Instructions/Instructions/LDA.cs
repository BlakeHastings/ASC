using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class LDA : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("1");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            machine.acc.setValue(machine.memory.GetAddress(new Hex(GetRelativeAddress(machine,instruction))));
            machine.memory.IncrementBuffer();
        }
    }
}
