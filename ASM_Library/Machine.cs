using ASM.Models;
using ASM.Opcode_Instructions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASM.Hardware_Components
{
    public class Machine : MachineBase
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
            supportedOpcodeInstructions.Add(new HLT(this).OPCODE, new HLT(this));
            supportedOpcodeInstructions.Add(new LDA(this).OPCODE, new LDA(this));
            supportedOpcodeInstructions.Add(new STA(this).OPCODE, new STA(this));
            supportedOpcodeInstructions.Add(new ADD(this).OPCODE, new ADD(this));
            supportedOpcodeInstructions.Add(new TCA(this).OPCODE, new TCA(this));
            supportedOpcodeInstructions.Add(new BRU(this).OPCODE, new BRU(this));
            supportedOpcodeInstructions.Add(new BIP(this).OPCODE, new BIP(this));
            supportedOpcodeInstructions.Add(new BIN(this).OPCODE, new BIN(this));
            supportedOpcodeInstructions.Add(new RWD(this).OPCODE, new RWD(this));
            supportedOpcodeInstructions.Add(new WWD(this).OPCODE, new WWD(this));
            supportedOpcodeInstructions.Add(new SHL(this).OPCODE, new SHL(this));
            supportedOpcodeInstructions.Add(new SHR(this).OPCODE, new SHR(this));
            supportedOpcodeInstructions.Add(new LDX(this).OPCODE, new LDX(this));
            supportedOpcodeInstructions.Add(new STX(this).OPCODE, new STX(this));
            supportedOpcodeInstructions.Add(new TIX(this).OPCODE, new TIX(this));
            supportedOpcodeInstructions.Add(new TDX(this).OPCODE, new TDX(this));
        }

        public void ExecuteCommand(AssembledInstruction instruction)
        {
            var hexOpCode = new Hex(Convert.ToInt32(instruction.Opcode, 2));
            if (supportedOpcodeInstructions.TryGetValue(hexOpCode, out var value))
                value.Invoke();
            else
                throw (new Exception("Unknown OpCode: " + hexOpCode));
        }

        public void Tick()
        {
            ExecuteCommand(new AssembledInstruction(memory.GetAddress(memory.BufferIndex).ToString()));
        }

        public void EndProgram()
        {
            EndOfProgram.Invoke();
            memory.BufferIndex = new Hex(0);
        }

        

    }
}
