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
        public string Label { get; private set; }
        public string Mnemonic { get; private set; }
        public string Operand { get; private set; }

        private Dictionary<string, InstructionsBase> supportedInstructions { get; }

        public PreAssembledInstruction(string instructionString, Dictionary<string, InstructionsBase> supportedInstructions, SymbolNode symbolLogicTree)
        {
            this.supportedInstructions = supportedInstructions;

            Parse(instructionString, symbolLogicTree);
        }

        private void Parse(string instructionString, SymbolNode symbolLogicTree)
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
