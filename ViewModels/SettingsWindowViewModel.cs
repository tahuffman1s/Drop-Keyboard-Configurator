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
using DropKeyboardConfigurator.Views;


namespace DropKeyboardConfigurator.ViewModels
{
    public class SettingsWindowViewModel : ViewModelBase
    {
        #region "Constructors"
            public SettingsWindowViewModel(DefaultFileLocationsModel _files, SettingsService _settings, SettingsModel _globalSettings, SettingsWindow _settingsWindow)
            {
                // Setting locals equal to the global configurations
                _SettingsService = new SettingsService();
                SettingsValues = _globalSettings;
                settingsLocation = _files.SettingsFileLocation;
                settingsWindow = _settingsWindow;
                defaultSettingsLocation = _files.DefaultSettingFileLocation;

                // Connecting reactive commands
                save = ReactiveCommand.Create(Save);
                reset = ReactiveCommand.Create(Reset);
                cancel = ReactiveCommand.Create(Cancel);

                // Form execution methods
                LoadSettingsFile();
            }
        #endregion

        #region "Private Variables"
            private SettingsModel settingsValues;
            private SettingsService _settingsService;
            private SettingsWindow settingsWindow;
            private DirectoryInfo settingsLocation;
            private DirectoryInfo defaultSettingsLocation;
            private string settingsData;
            private string defaultSettingsData;
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
            public string SettingsData
            {
                get => settingsData;
                set => this.RaiseAndSetIfChanged(ref settingsData, value);
            }
        #endregion

        #region "Command Bindings"
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> save { get; }
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> reset { get; }
            public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> cancel { get; }
        #endregion

        #region "Methods"
            public void LoadSettingsFile()
            {
                SettingsData = File.ReadAllText(SettingsLocation.FullName);
            }
            public void Save()
            {
                File.WriteAllText(SettingsLocation.FullName, SettingsData);
            }
            public void Cancel()
            {
                settingsWindow.Close();
            }
            public void Reset()
            {
                SettingsData = File.ReadAllText(defaultSettingsLocation.FullName);
            }
        #endregion
    }
}