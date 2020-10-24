using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASM.Models
{
    public class AssembledInstruction
    {
        public string Opcode { get; private set; }
        public string Extension_Bit { get; private set; }
        public string Indirect_Flag { get; private set; }
        public string Index_Flag { get; private set; }
        public string Address { get; private set; }

        public AssembledInstruction(string code)
        {
            code = code.Replace(" ", String.Empty);
            code.Trim();
            //Check if already binary
           
            if(code.Length != 16)
            {
                code = DecodeHexInstructions(code);
            }

            Opcode = code.Substring(0, 4);
            Extension_Bit = code.Substring(4, 1);
            Indirect_Flag = code.Substring(5,1);
            Index_Flag = code.Substring(6, 2);
            Address = code.Substring(8, 8);
        }

        public int OpcodeInt()
        {
            return Convert.ToInt32(Opcode, 2);
        }
        public int Extension_BitInt()
        {
            return Convert.ToInt32(Extension_Bit, 2);
        }
        public int Indirect_FlagInt()
        {
            return Convert.ToInt32(Indirect_Flag, 2);
        }
        public int Index_FlagInt()
        {
            return Convert.ToInt32(Index_Flag, 2);
        }
        public int AddressInt()
        {
            return Convert.ToInt32(Address, 2);
        }

        /// <summary>
        /// Provides conversion from Hex to Binary.
        /// </summary>
        /// <param name="code">Hexadecimal ASM line</param>
        /// <returns>Binary string. Throws error if binary string is not size 16</returns>
        private string DecodeHexInstructions(string hexCode)
        {
            string rtnString = "";
            rtnString += Convert.ToString(Convert.ToInt64(hexCode, 16), 2).PadLeft(16,'0');

            if (rtnString.Length < 15)
                throw new Exception($"Provided instruction is not of correct specification: size {rtnString.Length} is not expected size of 16");
            return rtnString;
        }

        public override string ToString()
        {
            return Opcode + Extension_Bit + Indirect_Flag + Index_Flag + Address;
        }
    }
}
