using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Assembler.Symbols
{
    public class SymbolNode : SymbolNodeBase
    {
        public override string Name { get; } = "SymbolBase";

        public override SymbolNodeArgs Invoke(SymbolNodeArgs args, Stack<string> tokenStack)
        {
            return base.InvokeChildren(args, tokenStack);
        }
    }
}
