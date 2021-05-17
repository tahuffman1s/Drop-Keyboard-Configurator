using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.IO;
using System.Reflection;
using ReactiveUI;
using DropKeyboardConfigurator.ViewModels;
using DropKeyboardConfigurator.Views;
using DropKeyboardConfigurator.Domain;
using DropKeyboardConfigurator.Models;

namespace DropKeyboardConfigurator
{
    public class App : Application
    {
        public override void Initialize()
        {
            _settingsService = new SettingsService();
            defaultFileLocations = new DefaultFileLocationsModel();
            operatingSystemsModel = new OperatingSystemsModel();
            settingsValues = _settingsService.LoadSettings(defaultFileLocations.SettingsFileLocation);
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(_settingsService, settingsValues, defaultFileLocations, operatingSystemsModel),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        #region "Theme Engine Values"
            private SettingsModel settingsValues;
            private SettingsService _settingsService;
        #endregion

        #region "File Location Values"
            private DefaultFileLocationsModel defaultFileLocations;
        #endregion

        #region "OS Type Model"
            private OperatingSystemsModel operatingSystemsModel;
        #endregion
    }
}