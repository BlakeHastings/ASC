using ASM.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace ASM.Assembler.Assembler_Instructions
{
    public abstract class AssemblerInstruction : InstructionsBase
    {
        public Assembler assembler;
        public AssemblerInstruction(Assembler _assembler)
        {
            assembler = _assembler;
        }

    }
}
