using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class LDX : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("C");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            machine.registers[instruction.Index_FlagInt() - 1].SetValue(machine.memory.GetAddress(instruction.AddressInt()));
            machine.memory.IncrementBuffer();
        }
    }
   
}
