using ASM.Core;
using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Opcode_Instructions
{
    public abstract class OpcodeInstructionBase : InstructionsBase
    {
        public abstract Hex OPCODE { get; }
        public Machine machine { get; }

        public OpcodeInstructionBase(Machine _machine) {
            machine = _machine;
        }

        public AssembledInstruction GetInstruction()
        {
            return new AssembledInstruction(machine.memory.GetAddress(machine.memory.BufferIndex).ToString());
        }

        public int GetRelativeAddress()
        {
            var relatedMemory = GetInstruction().AddressInt();
            if (GetInstruction().Index_Flag != "00")
                relatedMemory += machine.registers[GetInstruction().Index_FlagInt() - 1].Value;
            return relatedMemory;
        }
    }
}
