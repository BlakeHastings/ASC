using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASM.Assembler.Symbols
{
    public abstract class SymbolNodeBase
    {
        public abstract string Name { get; }
        public string TokenString { get; set; }
        public List<SymbolNodeBase> children = new List<SymbolNodeBase>();

        public abstract SymbolNodeArgs Invoke(SymbolNodeArgs args, Stack<string> tokenStack);

        internal SymbolNodeArgs InvokeChildren(SymbolNodeArgs args, Stack<string> tokenStack) {
            var tokenStackCopy = tokenStack;
            TokenString = "";
            if (args.Status != SymbolNodeStatus.None)
            {
                tokenStackCopy = new Stack<string>(new Stack<string>(tokenStack));
                TokenString = tokenStackCopy.Pop();
            }

            SymbolNodeArgs childArg;

            foreach (var child in children)
            {
                childArg = child.Invoke(args, tokenStackCopy);
                if (childArg.Status == SymbolNodeStatus.Pass)
                {
                    TokenString = tokenStack.Pop();
                    args.SymbolList.Push(this);
                    return args;
                }


            }

            if (args.Status == SymbolNodeStatus.Exception)
            {
                StringBuilder childrenList = new StringBuilder();
                foreach (var x in children)
                    childrenList.Append($"{x.Name} ");

                args.ExceptionList.Add(new Exception($"{TokenString} {Name} expected a token from following types: {childrenList.ToString()}"));
                return args;
            }

            if (args.Status == SymbolNodeStatus.Fail)
            {
                args.Status = SymbolNodeStatus.Fail;
                return args;
            }

            args.Status = SymbolNodeStatus.Pass;
            return args;


        }
    }
}
