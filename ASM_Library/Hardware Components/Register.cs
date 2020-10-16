using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Hardware_Components
{
    public class Register : HardwareBase
    {
        private Hex _Value = new Hex("0000");
        public Hex Value { get { return _Value; } private set { _Value = value; NotifyPropertyChanged(); } }

        public void SetValue(Hex hexValue)
        {
            if (hexValue.ToString().Length > 4)
                throw new Exception("INDEX_REGISTER: invalid hexValue");
            if (hexValue.ToString().Length < 4)
                throw new Exception("INDEX_REGISTER: invalid hexValue");
            Value = hexValue;
        }

        public void Increment()
        {
            Value++;
        }

        public void Decrement()
        {
            Value--;
        }
    }
}
