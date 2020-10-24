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

        public override string MNEMONIC { get; } = "LDX";

        public LDX(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            machine.registers[GetInstruction().Index_FlagInt() - 1].SetValue(machine.memory.GetAddress(GetInstruction().AddressInt()));
            machine.memory.IncrementBuffer();
        }
    }
   
}
