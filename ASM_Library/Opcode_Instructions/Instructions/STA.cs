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

        public override void Invoke(Machine machine, Instruction instruction)
        {
            var relativeAddress = instruction.AddressInt();
            if (instruction.Index_Flag != "00")
            {
                relativeAddress += machine.registers[instruction.Index_FlagInt() - 1].Value;
            }
            
            machine.memory.SetAddress(relativeAddress, machine.acc.HexValue.ToString());
            machine.memory.IncrementBuffer();
        }
    }
}
