using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ASM
{
    public class ProgramLoader
    {
        public void LoadFromFile(string path, Machine machine)
        {
            try
            {
                string[] instructionList = ParseObjFile(path);
                for (int i = 0; i < machine.memory.Size && i < instructionList.Length; i++)
                    machine.memory.SetAddress(i, instructionList[i]);
            }catch(Exception ex)
            {
                throw (new Exception("Instruction set too large for memory to hold!"));
            }
           
        }
        private string[] ParseObjFile(string path)
        {
            List<string> objFileLines;
            try
            {
                string objFileString = File.ReadAllText(path);
                objFileLines = objFileString.Split(new[] { "  ", "\n" }, StringSplitOptions.None).ToList<string>();
                int pos = 0;
                for (int i = 1; i < objFileLines.Count; i += 2, pos++)
                {
                    objFileLines[pos] = objFileLines[i];
                }
                objFileLines.RemoveRange(pos, objFileLines.Count - pos);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return objFileLines.ToArray();
        }
    }
}
