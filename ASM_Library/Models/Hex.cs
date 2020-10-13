using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ASM.Models
{
    public class Hex
    {
        private string Number { get; set; }

        public Hex(string hexCode)
        {
            Regex reg = new Regex("^[0-9A-F]+$");
            if (!reg.IsMatch(hexCode))
            {
                try
                {
                    var t = new Hex(Convert.ToInt32(hexCode));
                    this.Number = t.ToString();
                }
                catch
                {
                    throw new Exception($"Assigned Hex value is not valid: {hexCode}");
                }
            }
            else
            {
                this.Number = hexCode.PadLeft(4, '0');
            }
                
            
        }

        public Hex(int decimalValue)
        {
            var n = decimalValue.ToString("X4");
            Number = n.Substring(n.Length-4);   
        }

        public static Hex operator +(Hex f1, Hex f2)
        {
            return new Hex((int)f1 + (int)f2);
        }

        public static Hex operator ++(Hex f1)
        {
            return new Hex(f1+1);
        }

        public static Hex operator --(Hex f1)
        {
            return new Hex(f1 - 1);
        }

        public static implicit operator int(Hex d)
        {
            if (d.Number[0] == 'F')
            {
                return (Convert.ToInt32(d.Number, 16) << 20) >> 20;
            }
            return Convert.ToInt32(d.Number, 16);
        }

        public override string ToString()
        {
            return Number;
        }

        public override bool Equals(object obj)
        {
            if (obj.ToString() == this.ToString())
                return true;
            return false;
        }
    }
}
