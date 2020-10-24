using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Assembler.Assembler_Instructions.Instructions
{
    public class ORG : AssemblerInstruction
    {

        public override string MNEMONIC { get; } = "ADD";

        public ORG(Assembler assembler) : base(assembler) { }

        public override void Invoke()
        {
            
        }
    }
   
}
