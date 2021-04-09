using ReactiveUI;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Diagnostics;
using DropKeyboardConfigurator.Models;
using DropKeyboardConfigurator.Domain;

namespace DropKeyboardConfigurator.ViewModels
{
    public class SettingsWindowViewModel : ViewModelBase
    {
        #region "Constructors"
            public SettingsWindowViewModel()
            {
                _SettingsService = new SettingsService();
                SettingsLocation = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/settings.json");
                SettingsValues = _SettingsService.LoadSettings(SettingsLocation);
                var test = 1;
            }
        #endregion

        #region "Private Variables"
            private SettingsModel settingsValues;
            private SettingsService _settingsService;
            private DirectoryInfo settingsLocation;
        #endregion

        #region "Bindings"
            public SettingsModel SettingsValues
            {
                get => settingsValues;
                set => this.RaiseAndSetIfChanged(ref settingsValues, value);
            }
            public SettingsService _SettingsService
            {
                get => _settingsService;
                set => this.RaiseAndSetIfChanged(ref _settingsService, value);
            }
            public DirectoryInfo SettingsLocation
            {
                get => settingsLocation;
                set => this.RaiseAndSetIfChanged(ref settingsLocation, value);
            } 
        #endregion
    }
}