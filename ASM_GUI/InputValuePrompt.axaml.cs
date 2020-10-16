using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ASM_GUI
{
    public class InputValuePrompt : Window
    {
        public int value;
        public InputValuePrompt()
        {
            this.InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
