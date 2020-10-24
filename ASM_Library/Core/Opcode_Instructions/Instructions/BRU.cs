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

        public override string MNEMONIC { get; } = "BRU";

        public BRU(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            machine.memory.BufferIndex = new Hex(GetInstruction().AddressInt());
        }
    }
}
