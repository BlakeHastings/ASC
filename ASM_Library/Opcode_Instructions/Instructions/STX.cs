using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class STX : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("D");

        public override void Invoke(Machine machine, Instruction instruction)
        {
            var register = Convert.ToInt32(instruction.Index_Flag, 2) - 1;
            var address = Convert.ToInt32(instruction.Address, 2);
            machine.memory.SetAddress(address, machine.registers[register].Value.ToString());
            machine.memory.IncrementBuffer();
        }
    }
   
}
