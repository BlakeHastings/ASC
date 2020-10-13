using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public abstract class OpcodeInstructionBase
    {
        public abstract Hex OPCODE { get; }
        public abstract void Invoke(Machine machine, Instruction instruction);

        public int GetRelativeAddress(Machine machine, Instruction instruction)
        {
            var relatedMemory = instruction.AddressInt();
            if (instruction.Index_Flag != "00")
                relatedMemory += machine.registers[instruction.Index_FlagInt() - 1].Value;
            return relatedMemory;
        }
    }
}
