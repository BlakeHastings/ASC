using ASM;
using ASM.Hardware_Components;
using ASM.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaEdit;
using AvaloniaEdit.CodeCompletion;
using AvaloniaEdit.Document;
using AvaloniaEdit.Editing;
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Rendering;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ASM_GUI
{
    public class MainWindow : Window
    {
        private CompletionWindow _completionWindow;
        private OverloadInsightWindow _insightWindow;

        #region Private UI
        private TextEditor _textEditor { get; set; }

        private TextBlock accValue_TextBlock;
        private TextBlock register1Value_TextBlock;
        private TextBlock register2Value_TextBlock;
        private TextBlock register3Value_TextBlock;
        private TextBlock outputValue_TextBlock;
        private TextBlock inputValue_TextBlock;

        private Button LoadFile_Button;

        private int lastSelectedMem = 0;

        #region Settings Values
        private int _fontSize = 100;
        public int fontSize { 
            get {
                return _fontSize;
            }
            set {
                _fontSize = value;
                NotifyPropertyChanged();
            }
        }

        private int _toolTipDelay = 1000;
        public int toolTipDelay
        {
            get
            {
                return _toolTipDelay;
            }
            set
            {
                _toolTipDelay = value;
                NotifyPropertyChanged();
            }
        }

        private Avalonia.Media.FontWeight _fontWeight = FontWeight.Normal;
        public FontWeight fontWeight {
            get
            {
                return _fontWeight;
            }
            set
            {
                _fontWeight = value;
                NotifyPropertyChanged();
            }
        
        }

        #endregion


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

            machine.InputBuffer = new Hex(10);

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

            #region TextEditor
            _textEditor = this.FindControl<TextEditor>("Editor");
            _textEditor.Background = Brushes.Transparent;
            _textEditor.ShowLineNumbers = true;
            //_textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            _textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
            _textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            //_textEditor.TextArea.IndentationStrategy = new AvaloniaEdit.Indentation.CSharp.CSharpIndentationStrategy();
            

            this.AddHandler(PointerWheelChangedEvent, (o, i) =>
            {
                if (i.KeyModifiers != KeyModifiers.Control) return;
                if (i.Delta.Y > 0) _textEditor.FontSize++;
                else _textEditor.FontSize = _textEditor.FontSize > 1 ? _textEditor.FontSize - 1 : 1;
            }, RoutingStrategies.Bubble, true);

            #endregion

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
            int i = 0;
            AddClassToMemoryLocation(v, "PulseOrange");
        }

        public void MachineTick()
        {
            machine.Tick();
            SelectMemoryLocation(machine.memory.BufferIndex - 1);
        }

        private void AddClassToMemoryLocation(int v, string className)
        {
            int i = 0;
            foreach (Panel panel in memoryRepeater.GetLogicalChildren())
            {
                if (i == v)
                {
                    panel.Children[0].Classes.Remove(className);
                    panel.Children[0].Classes.Add(className);
                    break;
                }

                i++;
            }
        }

        private void RemoveClassFromMemoryLocation(int v, string className)
        {
            int i = 0;
            foreach (Panel panel in memoryRepeater.GetLogicalChildren())
            {
                if (i == v)
                {
                    panel.Children[0].Classes.Remove(className);
                    break;
                }

                i++;
            }
        }

        private void SelectMemoryLocation(int v)
        {
            RemoveClassFromMemoryLocation(lastSelectedMem, "Selected");
            RemoveClassFromMemoryLocation(machine.memory.BufferIndex - 1, "PulseOrange");
            AddClassToMemoryLocation(machine.memory.BufferIndex - 1, "Selected");
            lastSelectedMem = machine.memory.BufferIndex - 1;
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
            if(filePath.Length == 0)
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
                    _textEditor.Text += str + Environment.NewLine;

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
                MachineTick();
            }
            
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMemory(true);
        }

        public void Step(object sender, RoutedEventArgs e)
        {
            if(!isRan)
            {
                MachineTick();
            }  
        }

        void textEditor_TextArea_TextEntering(object sender, TextInputEventArgs e)
        {
            if (e.Text.Length > 0 && _completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    _completionWindow.CompletionList.RequestInsertion(e);
                }
            }

            _insightWindow?.Hide();

            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }


        void textEditor_TextArea_TextEntered(object sender, TextInputEventArgs e)
        {
            if (e.Text == ".")
            {

                _completionWindow = new CompletionWindow(_textEditor.TextArea);
                _completionWindow.Closed += (o, args) => _completionWindow = null;

                var data = _completionWindow.CompletionList.CompletionData;
                data.Add(new MyCompletionData("Item1"));
                data.Add(new MyCompletionData("Item2"));
                data.Add(new MyCompletionData("Item3"));
                data.Add(new MyCompletionData("Item4"));
                data.Add(new MyCompletionData("Item5"));
                data.Add(new MyCompletionData("Item6"));
                data.Add(new MyCompletionData("Item7"));
                data.Add(new MyCompletionData("Item8"));
                data.Add(new MyCompletionData("Item9"));
                data.Add(new MyCompletionData("Item10"));
                data.Add(new MyCompletionData("Item11"));
                data.Add(new MyCompletionData("Item12"));
                data.Add(new MyCompletionData("Item13"));


                _completionWindow.Show();
            }
            else if (e.Text == "(")
            {
                _insightWindow = new OverloadInsightWindow(_textEditor.TextArea);
                _insightWindow.Closed += (o, args) => _insightWindow = null;

                _insightWindow.Provider = new MyOverloadProvider(new[]
                {
                    ("Method1(int, string)", "Method1 description"),
                    ("Method2(int)", "Method2 description"),
                    ("Method3(string)", "Method3 description"),
                });

                _insightWindow.Show();
            }
        }

        public void settings_fontSize_changed(object sender, NumericUpDownValueChangedEventArgs e)
        {
            fontSize = (int)e.NewValue;
        }

        public void settings_toolTipDelay_changed(object sender, NumericUpDownValueChangedEventArgs e)
        {

            toolTipDelay = (int)e.NewValue * 1000;
        }

        public void settings_fontWeight_changed(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            fontWeight = (Avalonia.Media.FontWeight)comboBox.SelectedItem;
        }
        #endregion

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class MyOverloadProvider : IOverloadProvider
        {
            private readonly IList<(string header, string content)> _items;
            private int _selectedIndex;

            public MyOverloadProvider(IList<(string header, string content)> items)
            {
                _items = items;
                SelectedIndex = 0;
            }

            public int SelectedIndex
            {
                get => _selectedIndex;
                set
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                    // ReSharper disable ExplicitCallerInfoArgument
                    OnPropertyChanged(nameof(CurrentHeader));
                    OnPropertyChanged(nameof(CurrentContent));
                    // ReSharper restore ExplicitCallerInfoArgument
                }
            }

            public int Count => _items.Count;
            public string CurrentIndexText => null;
            public object CurrentHeader => _items[SelectedIndex].header;
            public object CurrentContent => _items[SelectedIndex].content;

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class MyCompletionData : ICompletionData
        {
            public MyCompletionData(string text)
            {
                Text = text;
            }

            public IBitmap Image => null;

            public string Text { get; }

            // Use this property if you want to show a fancy UIElement in the list.
            public object Content => Text;

            public object Description => "Description for " + Text;

            public double Priority { get; } = 0;

            public void Complete(TextArea textArea, ISegment completionSegment,
                EventArgs insertionRequestEventArgs)
            {
                textArea.Document.Replace(completionSegment, Text);
            }
        }

    }
}
