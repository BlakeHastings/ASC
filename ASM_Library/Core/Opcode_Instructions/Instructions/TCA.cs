using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class TCA : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("4");

        public override string MNEMONIC { get; } = "TCA";

        public TCA(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            machine.acc.setValue(new Hex(~(int)machine.acc.HexValue + 1));
            machine.memory.IncrementBuffer();
        }
    }
}
