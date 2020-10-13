using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Hardware_Components
{
    public class ACC
    {
        public Hex HexValue { get; private set; } = new Hex("0000");

        public void setValue(Hex hexValue)
        {
            if(hexValue == null)
                throw new Exception("ACC: invalid hexValue. Hex cannot be null! Something is wrong!");
            if (hexValue.ToString().Length > 4)
                throw new Exception("ACC: invalid hexValue");
            if (hexValue.ToString().Length < 4)
                throw new Exception("ACC: invalid hexValue");
            HexValue = hexValue;
        }

    }
}
