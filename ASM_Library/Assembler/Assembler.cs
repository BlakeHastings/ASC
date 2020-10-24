using ASM.Assembler.Assembler_Instructions;
using ASM.Assembler.Models;
using ASM.Assembler.Symbols;
using ASM.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ASM.Assembler
{
    public class Assembler : MachineBase
    {
        private Dictionary<string, InstructionsBase> supportedInstructions { get; set; } = new Dictionary<string, InstructionsBase>();
        public int locationCounter { get; set; } = 0;

        private Dictionary<string, int> symbolTable = new Dictionary<string, int>();

        public Assembler(List<InstructionsBase> _supportedInstructions)
        {
            foreach (var x in _supportedInstructions)
                supportedInstructions.Add(x.MNEMONIC, x);
        }

        public Assembler(Dictionary<int,InstructionsBase> machineOpcodes, List<AssemblerInstruction> assemblerInstructions)
        {
            foreach (var x in machineOpcodes)
                supportedInstructions.Add(x.Value.MNEMONIC, x.Value);
            foreach (var x in assemblerInstructions)
                supportedInstructions.Add(x.MNEMONIC, x);
        }

        public void Assemble(string path)
        {
            var asmText = "";
            try
            {
                asmText = File.ReadAllText(path);
            }
            catch(Exception ex)
            {
                throw (new Exception("Assembler cannot read file.", ex));
            }

            FirstPass(asmText);


        }

        /// <summary>
        /// Prepares a raw text document for ingestion by the assembler
        /// </summary>
        /// <param name="text">text from file to be processed</param>
        /// <returns>string where tabs are replaced by spaces</returns>
        private string TreatForProcessing(string text)
        {
            var rtnText = text;
            text = text.Replace("\t", " ");
            return text;
        }
    
        /// <summary>
        /// Gets individual lines of code
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string[] ParseLines(string text)
        {
            string[] processArr = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> rtnList = new List<string>(); //Fixed to expected size of machine memory
            
            for (int i = 0; i < processArr.Length; i++)
            {
                if (processArr[i] == "")
                    continue;
                string line = processArr[i];
                if(line.IndexOf('.') != -1)
                    line = line.Remove(processArr[i].IndexOf('.'));
                if (line[0] == '*')
                    line = "";
                rtnList.Add(line);
            }
            return rtnList.ToArray();
        }
    
        private void FirstPass(string text)
        {
            text = this.TreatForProcessing(text);
            var asmCodeLines = this.ParseLines(text);


            SymbolNode symbolLogicTree = 
                new SymbolNode() { 
                    children = new List<SymbolNodeBase>() {
                        new Label(),
                        new Mnemonic(new List<InstructionsBase>(supportedInstructions.Values))
                    }
                };


            foreach(string line in asmCodeLines)
            {

                if (line == "")
                    continue;


                var t = new PreAssembledInstruction(line, supportedInstructions, symbolLogicTree);
            }
        }

    }
}
