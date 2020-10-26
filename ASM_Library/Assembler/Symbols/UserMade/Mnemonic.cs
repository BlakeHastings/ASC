using ASM.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Assembler.Symbols
{
    public class Mnemonic : SymbolNodeBase
    {
        public override string Name { get; } = "Mnemonic";

        public InstructionsBase MnemonicObj { get; private set; }

        List<InstructionsBase> supportedInstructions = new List<InstructionsBase>();

        public Mnemonic(List<InstructionsBase> supportedInstructions)
        {
            this.supportedInstructions = supportedInstructions;
        }


        public override SymbolNodeArgs Invoke(SymbolNodeArgs args, Stack<string> tokenStack)
        {
            TokenString = tokenStack.Peek();

            if(TokenString.Length < 3 
                || TokenString.Length > 3)
            {
                args.Status = SymbolNodeStatus.Fail;
                return args;
            }

            foreach(InstructionsBase instruction in supportedInstructions)
            {
                if(instruction.MNEMONIC == TokenString)
                {
                    MnemonicObj = instruction;
                    args.SymbolList.Push(this);
                    args.Status = SymbolNodeStatus.Pass;
                    return base.InvokeChildren(args, tokenStack);
                }

            }

            args.Status = SymbolNodeStatus.Fail;
            return args;
        }
    }
}
