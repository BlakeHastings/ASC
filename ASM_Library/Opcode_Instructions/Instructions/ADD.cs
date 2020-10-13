using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class ADD : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("3");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            var relativeAddress = GetRelativeAddress(machine, instruction);
            machine.acc.setValue(machine.memory.GetAddress(relativeAddress) + machine.acc.HexValue);
            machine.memory.IncrementBuffer();
        }
    }
   
}
