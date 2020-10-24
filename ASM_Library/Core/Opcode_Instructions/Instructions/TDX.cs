using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class TDX : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("F");

        public override string MNEMONIC { get; } = "TDX";

        public TDX(Machine machine) : base(machine) { }
        public override void Invoke()
        {
            var register = Convert.ToInt32(GetInstruction().Index_Flag, 2) - 1;
            var address = Convert.ToInt32(GetInstruction().Address, 2);
            machine.registers[register].Decrement();
            if (machine.registers[register].Value != 0)
                machine.memory.BufferIndex = new Hex(address);
            else
                machine.memory.IncrementBuffer();
        }
    }
   
}
