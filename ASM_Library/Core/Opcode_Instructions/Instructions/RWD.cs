using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class RWD : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("8");

        public override string MNEMONIC { get; } = "RWD";

        public RWD(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            machine.GetInput?.Invoke();
            machine.acc.setValue(machine.InputBuffer);
            machine.memory.BufferIndex = new Hex(machine.memory.BufferIndex + 1);
            machine.InputBuffer = null;
        }
    }
}
