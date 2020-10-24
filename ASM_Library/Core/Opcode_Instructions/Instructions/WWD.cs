using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class WWD : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("9");

        public override string MNEMONIC { get; } = "WWD";

        public WWD(Machine machine) : base(machine) { }
        public override void Invoke()
        {
            machine.OutputBuffer = machine.acc.HexValue;
            machine.RecieveOutput.Invoke(machine.acc.HexValue);
            machine.memory.IncrementBuffer();
        }
    }
}
