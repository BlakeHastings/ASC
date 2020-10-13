using ASM;
using ASM.Hardware_Components;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_GUI
{
    public partial class Emulator : Form
    {
        private bool isRan = false;
        Machine machine;
        public Emulator()
        {
            InitializeComponent();
            machine = new Machine();
            
            machine.GetInput = () => {
                using (InputValuePrompt dlg = new InputValuePrompt())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        machine.InputBuffer = new Hex(dlg.value);
                    }
                }
            };

            machine.RecieveOutput = (hex) => {
                Output_Button.Text = Util.ConvertDataToSelectedBase(hex, (int)displayBase_ComboBox.SelectedItem);
            };

            machine.EndOfProgram = () => {
                isRan = true;
                using (Prompt dlg = new Prompt("End of program!","Okay"))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        
                    }
                }
            };

            memoryGrid_DataGridView.RowHeadersVisible = false;
            memoryGrid_DataGridView.RowTemplate.Height = 20;

            memoryGrid_DataGridView.ColumnHeadersVisible = false;
            memoryGrid_DataGridView.Columns.Add("Index","");
            memoryGrid_DataGridView.Columns.Add("Value", "");

            memoryGrid_DataGridView.Columns["Index"].Width = 40;
            memoryGrid_DataGridView.Columns["Index"].ReadOnly = true;
            memoryGrid_DataGridView.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            

            displayBase_ComboBox.DataSource = new int[] { 16, 10, 2,};
            displayBase_ComboBox.SelectedIndex = 1;

            machine.memory.AddressValueChanged += Memory_AddressValueChanged;
            Memory_AddressValueChanged(null, 0);
        }

        private void UpdateUi()
        {
            Memory_AddressValueChanged(null, 0);
            ACC_Button.Text = Util.ConvertDataToSelectedBase(machine.acc.HexValue,(int)displayBase_ComboBox.SelectedItem);
            Register_1_Button.Text = Util.ConvertDataToSelectedBase(machine.registers[0].Value, (int)displayBase_ComboBox.SelectedItem);
            Register_2_Button.Text = Util.ConvertDataToSelectedBase(machine.registers[1].Value, (int)displayBase_ComboBox.SelectedItem);
            Register_3_Button.Text = Util.ConvertDataToSelectedBase(machine.registers[2].Value, (int)displayBase_ComboBox.SelectedItem);
            if (machine.InputBuffer != null) 
                Input_Button.Text = Util.ConvertDataToSelectedBase(machine.InputBuffer, (int)displayBase_ComboBox.SelectedItem);
            if (machine.OutputBuffer != null)
                Output_Button.Text = Util.ConvertDataToSelectedBase(machine.InputBuffer, (int)displayBase_ComboBox.SelectedItem);
        }

        private void Memory_AddressValueChanged(object sender, int e)
        {
            for(int i = 0; i < machine.memory.Size; i++)
            {
                if(i >= memoryGrid_DataGridView.Rows.Count)
                {
                    var t = machine.memory.GetAddress(i);
                    var x = Util.ConvertInstructionToSelectedBase(t, (int)displayBase_ComboBox.SelectedItem);
                    memoryGrid_DataGridView.Rows.Add(
                        Util.ConvertDataToSelectedBase(i, (int)displayBase_ComboBox.SelectedItem),
                        x);
                }
                else
                {
                    memoryGrid_DataGridView.Rows[i].SetValues(new Object[] { 
                        Util.ConvertDataToSelectedBase(i, (int)displayBase_ComboBox.SelectedItem),
                        Util.ConvertInstructionToSelectedBase(machine.memory.GetAddress(i), (int)displayBase_ComboBox.SelectedItem)});
                }
            }
            memoryGrid_DataGridView.ClearSelection();
            memoryGrid_DataGridView.Rows[machine.memory.BufferIndex].Selected = true;
        }

        private void decodeTool_Button_Click(object sender, EventArgs e)
        {
            new DecodeInstructionTool().Show();
        }

        private void displayBase_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUi();
        }

        private void Emulator_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string filePath;
            string directory;
            string fileName;
            ProgramLoader pl = new ProgramLoader();
            openFileDialog1.Filter = "Simple Machine Files (*.ASM)|*.ASM";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filePath = openFileDialog1.FileName;
                directory = Path.GetDirectoryName(filePath);
                fileName = Path.GetFileNameWithoutExtension(filePath);
                

                if (File.Exists(directory + "\\" + fileName + ".obj"))
                {
                    richTextBox1.Text = File.ReadAllText(filePath);
                    pl.LoadFromFile(directory + "\\" + fileName + ".obj", machine);

                }
                else
                {
                    using (Prompt dlg = new Prompt($"File Missing! \n{fileName}.obj\n  Assemble the .ASM file to produce!", "Okay!"))
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
            }
        }

        private void memoryGrid_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
                new DecodeInstructionTool((string)memoryGrid_DataGridView.Rows[e.RowIndex].Cells[1].Value, (int)displayBase_ComboBox.SelectedItem).Show();
        }


        #region Register buttons
        private void ACC_Button_Click(object sender, EventArgs e)
        {
            using (InputValuePrompt dlg = new InputValuePrompt())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    machine.acc.setValue(new Hex(dlg.value));
                    UpdateUi();
                }
            }
        }

        private void Register_1_Button_Click(object sender, EventArgs e)
        {
            using (InputValuePrompt dlg = new InputValuePrompt())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    machine.registers[0].SetValue(new Hex(dlg.value));
                    UpdateUi();
                }
            }
        }

        private void Register_2_Button_Click(object sender, EventArgs e)
        {
            using (InputValuePrompt dlg = new InputValuePrompt())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    machine.registers[1].SetValue(new Hex(dlg.value));
                    UpdateUi();
                }
            }
        }

        private void Register_3_Button_Click(object sender, EventArgs e)
        {
            using (InputValuePrompt dlg = new InputValuePrompt())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    machine.registers[2].SetValue(new Hex(dlg.value));
                    UpdateUi();
                }
            }
        }




        #endregion

        private void Emulator_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void step_Button_Click(object sender, EventArgs e)
        {
            machine.Tick();
            UpdateUi();
        }

        private void run_Button_Click(object sender, EventArgs e)
        {
            if(isRan)
            {
                using (Prompt dlg = new Prompt("Please recompile the program to reset the memory!", "Okay!"))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }

            while (!isRan)
                machine.Tick();
        }
    }
}
