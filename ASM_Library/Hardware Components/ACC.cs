using ASM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASM.Hardware_Components
{
    public class ACC : HardwareBase
    {
        private Hex _HexValue = new Hex("0000");
        public Hex HexValue { get { return _HexValue; } private set { _HexValue = value; NotifyPropertyChanged(); } } 

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
