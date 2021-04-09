using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DropKeyboardConfigurator.Views
{
    public class DumpFirmwareWindow : Window
    {
        public DumpFirmwareWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}