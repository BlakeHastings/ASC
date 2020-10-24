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

        public override string MNEMONIC { get; } = "STX";

        public STX(Machine machine) : base(machine) { }
        public override void Invoke()
        {
            var register = Convert.ToInt32(GetInstruction().Index_Flag, 2) - 1;
            var address = Convert.ToInt32(GetInstruction().Address, 2);
            machine.memory.SetAddress(address, machine.registers[register].Value.ToString());
            machine.memory.IncrementBuffer();
        }
    }
   
}
