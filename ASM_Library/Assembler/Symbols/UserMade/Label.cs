using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Assembler.Symbols
{
    public class Label : SymbolNodeBase
    {
        public override string Name { get; } = "Label";

        public override SymbolNodeArgs Invoke(SymbolNodeArgs args, Stack<string> tokenStack)
        {
            TokenString = tokenStack.Peek();

            if(Char.IsDigit(TokenString[0]) 
                || (TokenString[0] == '*')
                || TokenString.Contains(",")
                || TokenString.Contains("+")
                || TokenString.Contains("-")
                )
            {
                args.Status = SymbolNodeStatus.Fail;
                return args;
            }

            args.Status = SymbolNodeStatus.Pass;
            return base.InvokeChildren(args, tokenStack);
        }
    }
}
