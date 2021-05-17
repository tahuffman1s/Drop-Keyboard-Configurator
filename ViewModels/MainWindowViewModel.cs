using ReactiveUI;
using Avalonia;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using DropKeyboardConfigurator.Models;
using DropKeyboardConfigurator.Domain;
using DropKeyboardConfigurator.Views;

namespace DropKeyboardConfigurator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Viewmodel for the main window. Main purpose is to connect all the other forms together.

        #region "Contructors"
            public MainWindowViewModel(SettingsService _settings, SettingsModel _globalSettings, DefaultFileLocationsModel _defaultFileLocations, OperatingSystemsModel _operatingSystemsModel)
            {
                // Setting locals equal to global configuration
                DefaultFileLocations = _defaultFileLocations;
                _SettingsService = _settings;
                SettingsValues = _globalSettings;
                operatingSystemsModel = _operatingSystemsModel;

                // Connecting reactive commands
                refresh = ReactiveCommand.Create(Refresh);
                flash = ReactiveCommand.Create(Flash);
                configure = ReactiveCommand.Create(Configure);
                settings = ReactiveCommand.Create(Settings);
                dumpFirmware = ReactiveCommand.Create(DumpFirmware);
            }
        #endregion

        #region "Private Values"

            // Local values for use within the main view model.
            private DefaultFileLocationsModel defaultFileLocations;

            private SettingsModel settingsValues;
            private SettingsService _settingsService;
            private OperatingSystemsModel operatingSystemsModel;
            
        #endregion

        #region "Bindings"
            // Bindings for objecs on the form.
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
            public DefaultFileLocationsModel DefaultFileLocations
            {
                get => defaultFileLocations;
                set => this.RaiseAndSetIfChanged(ref defaultFileLocations, value);
            }
        #endregion

        #region "Command Bindings"
            //
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> flash { get; }
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> refresh { get; }
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> configure { get; }
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> settings { get; }
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> dumpFirmware { get; }
        #endregion

        #region "Methods"
            public void Refresh()
            {
                
            }
            public void Flash()
            {
                
            }

            // This method opens up the Drop Keyboard configurator on the user's default web browser.
            // This requires different ways of opening it up for the Mac/Windows/Linux.
            public void Configure()
            {
                string DropConfigurator = "https://drop.com/mechanical-keyboards/configurator";
                try
                {
                    System.Diagnostics.Process.Start(DropConfigurator);
                }
                catch
                {
                    if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(operatingSystemsModel.osWindows))
                    {
                        DropConfigurator = DropConfigurator.Replace("&", "^&");
                        System.Diagnostics.Process.Start(new ProcessStartInfo("cmd", $"/c start {DropConfigurator}") { CreateNoWindow = true });
                    }
                    else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(operatingSystemsModel.osLinux))
                    {
                        Process.Start("xdg-open", DropConfigurator);
                    }
                    else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(operatingSystemsModel.osMac))
                    {
                        Process.Start("open", DropConfigurator);
                    }        
                }
            }
            public void Settings()
            {
                var settingsWindow = new SettingsWindow();
                var SettingsWindowViewModel = new SettingsWindowViewModel(DefaultFileLocations, _SettingsService, SettingsValues, settingsWindow);
                settingsWindow.DataContext = SettingsWindowViewModel;
                settingsWindow.Show();
            }
            public void DumpFirmware()
            {
                var dumpFirwareWindow = new DumpFirmwareWindow();
                dumpFirwareWindow.Show();
            }
        #endregion
    }
}
