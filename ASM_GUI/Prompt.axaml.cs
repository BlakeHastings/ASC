using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ASM_GUI
{
    public class Prompt : Window
    {
        public string label;
        public string buttonLabel;

        public Prompt()
        {

        }

        public Prompt(string label, string button_label)
        {


            this.InitializeComponent();


            this.label = label;
            buttonLabel = button_label;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
