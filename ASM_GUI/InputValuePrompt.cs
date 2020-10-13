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
    public partial class InputValuePrompt : Form
    {
        public int value;

        public InputValuePrompt()
        {
            InitializeComponent();
            displayBase_ComboBox.DataSource = new int[] { 16, 10, 2, };
            displayBase_ComboBox.SelectedIndex = 1;
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            if ((int)displayBase_ComboBox.SelectedItem == 16)
                value = new Hex(textBox1.Text);
            else
                value = Convert.ToInt32(textBox1.Text, (int)displayBase_ComboBox.SelectedItem);
        }

        private void displayBase_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
