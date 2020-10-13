using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASM_GUI
{
    public partial class Prompt : Form
    {
        public Prompt(string label, string button_label)
        {
            
            InitializeComponent();
            label2.Text = label;
            button1.Text = button_label;
        }
    }
}
