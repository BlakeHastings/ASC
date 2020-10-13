using ASM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASM_GUI
{
    public partial class DecodeInstructionTool : Form
    {
        public string textBox;

        public DecodeInstructionTool()
        {
            InitializeComponent();
        }

        public DecodeInstructionTool(string input, int baseInt)
        {
            InitializeComponent();
            instructionEntry_TextBox.Text = new Hex(Convert.ToInt32(input, baseInt)).ToString();
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction(instructionEntry_TextBox.Text);
            opCode_TextBox.Text = instruction.Opcode;
            extensionBit_TextBox.Text = instruction.Extension_Bit;
            indirectFlag_TextBox.Text = instruction.Indirect_Flag;
            indexFlag_TextBox.Text = instruction.Index_Flag;
            address_TextBox.Text = instruction.Address;
        }
    }
}
