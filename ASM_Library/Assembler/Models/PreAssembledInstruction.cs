using ASM.Assembler.Assembler_Instructions;
using ASM.Assembler.Symbols;
using ASM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASM.Assembler.Models
{
    public class PreAssembledInstruction
    {
        private Dictionary<string, InstructionsBase> supportedInstructions { get; }

        public PreAssembledInstruction(string instructionString, Dictionary<string, InstructionsBase> supportedInstructions, SymbolNodeBase symbolLogicTree)
        {
            this.supportedInstructions = supportedInstructions;

            Parse(instructionString, symbolLogicTree);
        }

        private void Parse(string instructionString, SymbolNodeBase symbolLogicTree)
        {
            var t = symbolLogicTree.Invoke(new SymbolNodeArgs(), new Stack<string>(instructionString.Trim().Split(' ').Reverse()));
        }



        private enum SymbolTypes {
            Label,
            Mnemonic,
            Operand,
        }


        
    }

}
