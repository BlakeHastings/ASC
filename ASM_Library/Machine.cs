using ASM.Models;
using ASM.Opcode_Instructions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASM.Hardware_Components
{
    public class Machine : HardwareBase
    {

        public Action GetInput;
        public Action<Hex> RecieveOutput;
        public Action EndOfProgram;

        #region private fields
        private ACC _acc = new ACC();
        private Memory _memory = new Memory();
        private Register[] _registers = { new Register(), new Register(), new Register() };
        private Hex _InputBuffer;
        private Hex _OutputBuffer;
        #endregion

        public ACC acc { 
            get { return _acc; }
            private set { _acc = value; NotifyPropertyChanged(); } }
        public Memory memory {
            get { return _memory; }
            private set { _memory = value; NotifyPropertyChanged(); } }
        public Register[] registers {
            get { return _registers; }
            private set { _registers = value; NotifyPropertyChanged(); } }

        public Hex InputBuffer {
            get { return _InputBuffer; }
            set { _InputBuffer = value; NotifyPropertyChanged(); } }

        public Hex OutputBuffer {
            get { return _OutputBuffer; }
            set { _OutputBuffer = value; NotifyPropertyChanged(); } } 

        public Dictionary<int, OpcodeInstructionBase> supportedOpcodeInstructions = new Dictionary<int, OpcodeInstructionBase>();



        public Machine()
        {
            supportedOpcodeInstructions.Add(new HLT().OPCODE, new HLT());
            supportedOpcodeInstructions.Add(new LDA().OPCODE, new LDA());
            supportedOpcodeInstructions.Add(new STA().OPCODE, new STA());
            supportedOpcodeInstructions.Add(new ADD().OPCODE, new ADD());
            supportedOpcodeInstructions.Add(new TCA().OPCODE, new TCA());
            supportedOpcodeInstructions.Add(new BRU().OPCODE, new BRU());
            supportedOpcodeInstructions.Add(new BIP().OPCODE, new BIP());
            supportedOpcodeInstructions.Add(new BIN().OPCODE, new BIN());
            supportedOpcodeInstructions.Add(new RWD().OPCODE, new RWD());
            supportedOpcodeInstructions.Add(new WWD().OPCODE, new WWD());
            supportedOpcodeInstructions.Add(new SHL().OPCODE, new SHL());
            supportedOpcodeInstructions.Add(new SHR().OPCODE, new SHR());
            supportedOpcodeInstructions.Add(new LDX().OPCODE, new LDX());
            supportedOpcodeInstructions.Add(new STX().OPCODE, new STX());
            supportedOpcodeInstructions.Add(new TIX().OPCODE, new TIX());
            supportedOpcodeInstructions.Add(new TDX().OPCODE, new TDX());
        }

        public void ExecuteCommand(Instruction instruction)
        {
            var hexOpCode = new Hex(Convert.ToInt32(instruction.Opcode, 2));
            if (supportedOpcodeInstructions.TryGetValue(hexOpCode, out var value))
                value.Invoke(this,instruction);
            else
                throw (new Exception("Unknown OpCode: " + hexOpCode));
        }

        public void Tick()
        {
            ExecuteCommand(new Instruction(memory.GetAddress(memory.BufferIndex).ToString()));
        }

        public void EndProgram()
        {
            EndOfProgram.Invoke();
            memory.BufferIndex = new Hex(0);
        }

        

    }
}
