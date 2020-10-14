using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ASM_GUI
{
    public class MainWindow : Window
    {
        TextBox codeEditor;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            codeEditor = this.FindControl<TextBox>("codeEditor");
        }
    }
}
