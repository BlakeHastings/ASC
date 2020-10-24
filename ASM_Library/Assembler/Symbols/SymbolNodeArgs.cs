using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Assembler.Symbols
{
    public class SymbolNodeArgs
    {
        public Stack<SymbolNodeBase> SymbolList = new Stack<SymbolNodeBase>();
        public List<Exception> ExceptionList = new List<Exception>();
        public SymbolNodeStatus Status = SymbolNodeStatus.None;
    }

    public enum SymbolNodeStatus
    {
        None,
        Exception,
        Fail,
        Pass
    }
}
