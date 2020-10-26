using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Assembler.Symbols
{
    public class Operand : SymbolNodeBase
    {
        public override string Name { get; } = "Operand";

        public Hex Value;
        public string ValueLabel;
        public int RegisterFlag;
        public int OffsetSign;
        public uint Offset;
        public string OffsetLabel;
        

        public override SymbolNodeArgs Invoke(SymbolNodeArgs args, Stack<string> tokenStack)
        {
            var tokenString = tokenStack.Peek();

            if (int.TryParse(tokenString, out var value))
            {
                Value = new Hex(value);
                args.Status = SymbolNodeStatus.Pass;
                return base.InvokeChildren(args, tokenStack);
            }
           
            try
            {
                if (tokenString[0] == '#')
                {
                    if (tokenString[1] == 'H')
                    {
                        Value = new Hex(tokenString.Substring(1));
                        args.Status = SymbolNodeStatus.Pass;
                    }

                    if (tokenString[1] == 'O')
                    {
                        Value = new Hex(Convert.ToInt32(tokenString.Substring(1), 8));
                        args.Status = SymbolNodeStatus.Pass;
                    }

                    if (tokenString[1] == 'B')
                    {
                        Value = new Hex(Convert.ToInt32(tokenString.Substring(1), 2));
                        args.Status = SymbolNodeStatus.Pass;
                    }
                }
            }
            catch
            {
                args.Status = SymbolNodeStatus.Exception;
                args.ExceptionList.Add(new Exception($"{Name} syntax error. # found but following syntax is not correct"));
                return args;
            }
            

            var labelCheck = new Label().Invoke(new SymbolNodeArgs(), new Stack<string>(new List<string>() { tokenString }));
            if (labelCheck.Status == SymbolNodeStatus.Pass)
            {
                ValueLabel = tokenString;
                args.Status = SymbolNodeStatus.Pass;
                return base.InvokeChildren(args, tokenStack);
            }

            //Index Register is used
            var splitByComma = TokenString.Split(',');
            if (splitByComma.Length > 1)
            {
                if (int.TryParse(splitByComma[1], out var parseRes) && parseRes < 3)
                {
                    RegisterFlag = parseRes;
                }
                else
                {
                    args.ExceptionList.Add(new Exception($"{Name} provided index register {splitByComma[1]} is not valid."));
                    args.Status = SymbolNodeStatus.Exception;
                    return args;
                }
            }


            return base.InvokeChildren(args, tokenStack);
        }


        public bool TryParseOffsetValue(string TokenString)
        {
            

            //Check if left side is label - literal
            var offSetSignSplit = TokenString.Split(new char[] { '-' });
            if (offSetSignSplit.Length == 2)
            {
                if(new Label().Invoke(new SymbolNodeArgs(), new Stack<string>(new List<string>() { offSetSignSplit[0] })).Status == SymbolNodeStatus.Pass)
                {
                    ValueLabel = offSetSignSplit[0];
                    OffsetSign = '-';
                }

                if (new Label().Invoke(new SymbolNodeArgs(), new Stack<string>(new List<string>() { offSetSignSplit[1] })).Status == SymbolNodeStatus.Pass)
                {
                    OffsetLabel = offSetSignSplit[1];
                }
            }

            //Check if left side is label + literal
            offSetSignSplit = TokenString.Split(new char[] { '+' });
            if (offSetSignSplit.Length == 2)
            {
                if (new Label().Invoke(new SymbolNodeArgs(), new Stack<string>(new List<string>() { offSetSignSplit[0] })).Status == SymbolNodeStatus.Pass)
                {
                    OffsetLabel = offSetSignSplit[0];
                    OffsetSign = '+';
                }

                if (new Label().Invoke(new SymbolNodeArgs(), new Stack<string>(new List<string>() { offSetSignSplit[1] })).Status == SymbolNodeStatus.Pass)
                {
                    OffsetLabel = offSetSignSplit[1];
                }
            }



            return false;
        }
    }

    
}
