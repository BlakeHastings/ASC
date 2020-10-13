using ASM.Models;
using ASM.Opcode_Instructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM.Hardware_Components
{
    public class Machine
    {
        public Action GetInput;
        public Action<Hex> RecieveOutput;
        public Action EndOfProgram;
        public ACC acc { get; } = new ACC();
        public Memory memory { get; } = new Memory();
        public Register[] registers { get; } = { new Register(), new Register(), new Register() };
        public Hex InputBuffer { get; set; }
        public Hex OutputBuffer { get; set; } 
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
