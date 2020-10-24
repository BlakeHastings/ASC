using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public class STA : OpcodeInstructionBase
    {
        public override Hex OPCODE { get; } = new Hex("2");

        public override string MNEMONIC { get; } = "STA";

        public STA(Machine machine) : base(machine) { }

        public override void Invoke()
        {
            var relativeAddress = GetInstruction().AddressInt();
            if (GetInstruction().Index_Flag != "00")
            {
                relativeAddress += machine.registers[GetInstruction().Index_FlagInt() - 1].Value;
            }
            
            machine.memory.SetAddress(relativeAddress, machine.acc.HexValue.ToString());
            machine.memory.IncrementBuffer();
        }
    }
}
