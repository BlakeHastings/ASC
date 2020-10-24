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

        public override string MNEMONIC { get; } = "LDA";

        public LDA(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            machine.acc.setValue(machine.memory.GetAddress(new Hex(GetRelativeAddress())));
            machine.memory.IncrementBuffer();
        }
    }
}
