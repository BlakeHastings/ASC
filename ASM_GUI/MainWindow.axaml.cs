using ASM;
using ASM.Hardware_Components;
using ASM.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;

namespace ASM_GUI
{
    public class MainWindow : Window
    {
        #region Private UI
        private TextBox codeEditor { get; set; }

        private TextBlock accValue_TextBlock;
        private TextBlock register1Value_TextBlock;
        private TextBlock register2Value_TextBlock;
        private TextBlock register3Value_TextBlock;
        private TextBlock outputValue_TextBlock;
        private TextBlock inputValue_TextBlock;

        private Button LoadFile_Button;
        public int fontSize { get; set; } = 100;



        private TextBlock accLabel_TextBlock;
        private TextBlock register1Label_TextBlock;
        private TextBlock register2Label_TextBlock;
        private TextBlock register3Label_TextBlock;
        private TextBlock outputLabel_TextBlock;
        private TextBlock inputLabel_TextBlock;

        private ComboBox displayBase_ComboBox;
        private ObservableCollection<MemoryModel> MemoryItems { get; set; } = new ObservableCollection<MemoryModel>();


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private Machine machine;
        private int displayBase { get { return (int)displayBase_ComboBox.SelectedItem; } }
        private bool isRan = false;
        private StackPanel memory;
        private ItemsRepeater memoryRepeater;

        //TextBox register3_TextBlock;
        //TextBox register3_TextBlock;
        //TextBox register3_TextBlock;
        //TextBox register3_TextBlock;

        public MainWindow()
        {
            machine = new Machine();

            InitializeComponent();

            BindMachineEventsToUiComponents();
            InitUIEventHandlers();

            machine.GetInput = () => {
                    InputValuePrompt dlg = new InputValuePrompt();
                    var t = dlg.ShowDialog(this);
                    t.Wait();
                    machine.InputBuffer = new Hex(dlg.value);
            };

            machine.RecieveOutput = (hex) => {
                //outputValue_TextBlock.Text = Util.ConvertDataToSelectedBase(hex, displayBase);
            };
            machine.EndOfProgram += () => { isRan = true; };
            
        }
        
        private void BindMachineEventsToUiComponents()
        {
            machine.acc.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                accValue_TextBlock.Text = Util.ConvertDataToSelectedBase(machine.acc.HexValue, displayBase);
            };

            machine.registers[0].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                register1Value_TextBlock.Text = Util.ConvertDataToSelectedBase(machine.registers[0].Value, displayBase);
            };

            machine.registers[1].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                register2Value_TextBlock.Text = Util.ConvertDataToSelectedBase(machine.registers[1].Value, displayBase);
            };

            machine.registers[2].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                register3Value_TextBlock.Text = Util.ConvertDataToSelectedBase(machine.registers[2].Value, displayBase);
            };

            machine.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                switch (e.PropertyName) {
                    case "InputBuffer":
                        inputValue_TextBlock.Text = Util.ConvertDataToSelectedBase(machine.InputBuffer, displayBase);
                        break;
                    case "OutputBuffer":
                        outputValue_TextBlock.Text = Util.ConvertDataToSelectedBase(machine.OutputBuffer, displayBase);
                        break;
                }

            };

            //machine.acc.setValue(new Hex(10));
            
        }

        private void Acc_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void InitializeComponent()
        {
            
            AvaloniaXamlLoader.Load(this);
            

            codeEditor = this.FindControl<TextBox>("codeEditor");
            accValue_TextBlock = this.FindControl<TextBlock>("accValue_TextBlock");
            register1Value_TextBlock = this.FindControl<TextBlock>("register1Value_TextBlock");
            register2Value_TextBlock = this.FindControl<TextBlock>("register2Value_TextBlock");
            register3Value_TextBlock = this.FindControl<TextBlock>("register3Value_TextBlock");
            outputValue_TextBlock = this.FindControl<TextBlock>("outputValue_TextBlock");
            inputValue_TextBlock = this.FindControl<TextBlock>("inputValue_TextBlock");

            accLabel_TextBlock = this.FindControl<TextBlock>("accLabel_TextBlock");
            register1Label_TextBlock = this.FindControl<TextBlock>("register1Label_TextBlock");
            register2Label_TextBlock = this.FindControl<TextBlock>("register2Label_TextBlock");
            register3Label_TextBlock = this.FindControl<TextBlock>("register3Label_TextBlock");
            outputLabel_TextBlock = this.FindControl<TextBlock>("outputLabel_TextBlock");
            inputLabel_TextBlock = this.FindControl<TextBlock>("inputLabel_TextBlock");
            
            displayBase_ComboBox = this.Find<ComboBox>("displayBase_ComboBox");
            displayBase_ComboBox.Items = new int[] { 16, 10, 2, };
            displayBase_ComboBox.SelectedIndex = 0;

            LoadFile_Button = this.FindControl<Button>("LoadFile_Button"); 

            memory = this.Find<StackPanel>("memory");
            memoryRepeater = this.Find<ItemsRepeater>("memoryRowRepeater");
            
            memoryRepeater.Items = MemoryItems;

            machine.memory.AddressValueChanged += Memory_AddressValueChanged;
            LoadMemory(true);
            
            
        }

        private void Memory_AddressValueChanged(object p, int v)
        {
            MemoryItems[v].Data = Util.ConvertInstructionToSelectedBase(machine.memory.GetAddress(v), displayBase);
        }

        private void LoadMemory(bool rewrite = false)
        {
            if (rewrite)
            {
                MemoryItems.Clear();
                for (int i = 0; i < machine.memory.Size; i++)
                {
                    MemoryItems.Add(
                        new MemoryModel()
                        {
                            Address = Util.ConvertDataToSelectedBase(i, displayBase),
                            Data = Util.ConvertInstructionToSelectedBase(machine.memory.GetAddress(i), displayBase)
                        });
                }
            }
            else
            {
                for (int i = 0; i < machine.memory.Size; i++)
                {
                    MemoryItems[i].Address = Util.ConvertDataToSelectedBase(i, displayBase);
                    MemoryItems[i].Data = Util.ConvertInstructionToSelectedBase(machine.memory.GetAddress(i), displayBase);
                }
            }
            
        }

        #region UI Event Handlers

        private void InitUIEventHandlers()
        {
            LoadFile_Button.Click += LoadFile_Button_Click;
        }

        private async void LoadFile_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] filePath;
            string directory;
            string fileName;
            ProgramLoader pl = new ProgramLoader();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            

            filePath = await openFileDialog.ShowAsync(this);
            if(filePath == null)
            {
                return;
            }
            directory = Path.GetDirectoryName(filePath[0]);
            fileName = Path.GetFileNameWithoutExtension(filePath[0]);


            if (File.Exists(directory + "\\" + fileName + ".obj"))
            {
               var tempText = File.ReadAllText(filePath[0]);
                string tempTextBuffer = "";
                string[] tempTextLines = tempText.Split(Environment.NewLine);
                //for (int index = 0; index < tempTextLines.Length - 1; index++)
                //{
                //    for(int chrIndex = 0; chrIndex < tempTextLines[index].Length - 1; chrIndex++)
                //    {
                //        if(tempTextLines[index][chrIndex] == '\t')
                //        {
                            
                //            var dif = 10 - (chrIndex % 10);
                //            var spaces = "";
                //            for (int i = 0; i < dif; i++)
                //                spaces += " ";

                //            tempTextLines[index] = tempTextLines[index].Remove(chrIndex, 1);
                //            tempTextLines[index] = tempTextLines[index].Insert(chrIndex, spaces);
                //        }
                //    }


                //}

                foreach (string str in tempTextLines)
                    codeEditor.Text += str + Environment.NewLine;

                pl.LoadFromFile(directory + "\\" + fileName + ".obj", machine);
                LoadMemory(true);
            }
            else
            {
                Prompt dlg = new Prompt($"File Missing! \n{fileName}.obj\n  Assemble the .ASM file to produce!", "Okay!");
                dlg.ShowDialog(this);
            }
        }

        public void RunFile(object sender, RoutedEventArgs e)
        {
            while(isRan == false)
            {
                machine.Tick();
            }
            
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMemory(true);
        }


        #endregion


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
