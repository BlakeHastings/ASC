using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class ADD : OpcodeInstructionBase
    {
        
        public override Hex OPCODE { get; } = new Hex("3");

        public override string MNEMONIC { get; } = "ADD";

        public ADD(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            var relativeAddress = GetRelativeAddress();
            machine.acc.setValue(machine.memory.GetAddress(relativeAddress) + machine.acc.HexValue);
            machine.memory.IncrementBuffer();
        }
    }
   
}
