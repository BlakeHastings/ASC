using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class HLT : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("0");

        public override string MNEMONIC { get; } = "HLT";

        public HLT(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            machine.EndProgram();
        }
    }
}
