using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Hardware_Components
{
    public class Memory
    {
        public event EventHandler<int> AddressValueChanged;
        private Hex[] _mem { get; } = new Hex[255];
        private Hex _BufferIndex;
        public Hex BufferIndex {
            get
            {
                return _BufferIndex;
            }
            set {
                if (value > 255 || value < 0)
                    throw new Exception($"Invalid memory index supplied to buffer: {value}");
                _BufferIndex = new Hex(value);
            } 
        } 
        public int Size = 255;

        public Memory()
        {
            _BufferIndex = new Hex(0);
        }

        public void SetAddress(int decimalIndex, string hexValue)
        {
            _mem[decimalIndex] = new Hex(hexValue);
            AddressValueChanged?.Invoke(this,decimalIndex);
        }

        public void SetAddress(Hex index, string hexValue)
        {
            SetAddress(index, hexValue);
        }

        public Hex GetAddress(Hex index)
        {
            return _mem[index] ?? null;
        }

        public Hex GetAddress(int index)
        {
            var t = GetAddress(new Hex(index));
            return GetAddress(new Hex(index));
        }

        public void IncrementBuffer()
        {
            BufferIndex++;
        }

    }
}
