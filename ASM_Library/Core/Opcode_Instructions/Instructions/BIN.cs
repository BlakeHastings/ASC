using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class BIN : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("7");

        public override string MNEMONIC { get; } = "BIN";

        public BIN(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            if (machine.acc.HexValue < 0)
                machine.memory.BufferIndex = new Hex(GetInstruction().AddressInt());
            else
                machine.memory.IncrementBuffer();
        }
    }
}
