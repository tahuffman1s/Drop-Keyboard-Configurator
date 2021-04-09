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

        #region "Contructors"
            public MainWindowViewModel()
            {
                _SettingsService = new SettingsService();
                AssignDefaultLocations();
                SettingsValues = _SettingsService.LoadSettings(SettingsFileLocation);
                refresh = ReactiveCommand.Create(Refresh);
                flash = ReactiveCommand.Create(Flash);
                configure = ReactiveCommand.Create(Configure);
                settings = ReactiveCommand.Create(Settings);
                dumpFirmware = ReactiveCommand.Create(DumpFirmware);
            }
        #endregion

        #region "Private Values"
            private SettingsModel settingsValues;
            private SettingsService _settingsService;
            private DirectoryInfo mdFlashLocationLinux;
            private DirectoryInfo settingsFileLocation;
            private DirectoryInfo mdFlashLocationWindows;
            private DirectoryInfo mdFlashLocationMac;
            private DirectoryInfo defaultProfileFolderDirectory;
            private DirectoryInfo defaultAppletMdFlashBinLocation;
            private System.Runtime.InteropServices.OSPlatform osLinux = System.Runtime.InteropServices.OSPlatform.Linux;
            private System.Runtime.InteropServices.OSPlatform osWindows = System.Runtime.InteropServices.OSPlatform.Windows;
            private System.Runtime.InteropServices.OSPlatform osMac = System.Runtime.InteropServices.OSPlatform.OSX;    
            // private string theme;
            // private string background;
            // private string buttonBackground;
            // private string buttonBorder;
            // private string fileBoxBackground;
            // private string fileBoxBorder;
            // private string menuBackground;
            // private string menuAccent;
            // private bool useDefaultProfileFolderLocation;
            // private bool useDefaultMDFlashLocations;
            // private bool useDefaultAppletMdFlashBinLocation;
            // private string profileFolderLocation;
            // private string mdFlashLocation;
            // private string appletMdFlashBinLocation;orm osMac = System.Runtime.InteropServices.OSPlatform.OSX;
            // private string theme;
            // private string background;
            // private string buttonBackground;
            // private string buttonBorder;
            // private string fileBoxBackground;
            // private string fileBoxBorder;
            // private string menuBackground;
            // private string menuAccent;
            // private bool useDefaultProfileFolderLocation;
            // private bool useDefaultMDFlashLocations;
            // private bool useDefaultAppletMdFlashBinLocation;
            // private string profileFolderLocation;
            // private string mdFlashLocation;
            // private string appletMdFlashBinLocation;
        #endregion

        #region "Bindings"
            public DirectoryInfo MdFlashLocationLinux
            {
                get => mdFlashLocationLinux;
                set => this.RaiseAndSetIfChanged(ref mdFlashLocationLinux, value);
            }
            public DirectoryInfo MdFlashLocationWindows
            {
                get => mdFlashLocationWindows;
                set => this.RaiseAndSetIfChanged(ref mdFlashLocationWindows, value);
            }
            public DirectoryInfo MdFlashLocationMac
            {
                get => mdFlashLocationMac;
                set => this.RaiseAndSetIfChanged(ref mdFlashLocationMac, value);
            }
            public DirectoryInfo DefaultProfileFolderDirectory
            {
                get => defaultProfileFolderDirectory;
                set => this.RaiseAndSetIfChanged(ref defaultProfileFolderDirectory, value);
            }
            public DirectoryInfo DefaultAppletMdFlashBinLocation
            {
                get => defaultAppletMdFlashBinLocation;
                set => this.RaiseAndSetIfChanged(ref defaultAppletMdFlashBinLocation, value);
            }
            public DirectoryInfo SettingsFileLocation
            {
                get => settingsFileLocation;
                set => this.RaiseAndSetIfChanged(ref settingsFileLocation, value);
            }
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
            // public string Theme
            // {
            //     get => theme;
            //     set => this.RaiseAndSetIfChanged(ref theme, value);
            // }
            // public string Background
            // {
            //     get => background;
            //     set => this.RaiseAndSetIfChanged(ref background, value);
            // }
            // public string ButtonBackground
            // {
            //     get => buttonBackground;
            //     set => this.RaiseAndSetIfChanged(ref buttonBackground, value);
            // }
            // public string ButtonBorder
            // {
            //     get => buttonBorder;
            //     set => this.RaiseAndSetIfChanged(ref buttonBorder, value);
            // }Name
            // public string FileBoxBackground
            // {
            //     get => fileBoxBackground;
            //     set => this.RaiseAndSetIfChanged(ref fileBoxBackground, value);
            // }
            // public string MenuBackground
            // {
            //     get => menuBackground;
            //     set => this.RaiseAndSetIfChanged(ref menuBackground, value);
            // }
            // public string MenuAccent
            // {
            //     get => menuAccent;
            //     set => this.RaiseAndSetIfChanged(ref menuAccent, value);
            // }
            // public string ProfileFolderLocation 
            // {Name
            //     get => profileFolderLocation;
            //     set => this.RaiseAndSetIfChanged(ref profileFolderLocation, value);
            // }
            // public string MdFlashLocation
            // {
            //     get => mdFlashLocation;
            //     set => this.RaiseAndSetIfChanged(ref mdFlashLocation, value);
            // }
            // public string AppletMdFlashBinLocation
            // {
            //     get => appletMdFlashBinLocation;
            //     set => this.RaiseAndSetIfChanged(ref appletMdFlashBinLocation, value);
            // }
            // public bool UseDefaultProfileFolderLocation
            // {
            //     get => useDefaultProfileFolderLocation;
            //     set => this.RaiseAndSetIfChanged(ref useDefaultProfileFolderLocation, value);
            // }
            // public bool UseDefaultMDFlashLocations
            // {
            //     get => useDefaultMDFlashLocations;
            //     set => this.RaiseAndSetIfChanged(ref useDefaultMDFlashLocations, value);
            // }
            // public bool UseDefaultAppletMdFlashBinLocation
            // {
            //     get => useDefaultAppletMdFlashBinLocation;
            //     set => this.RaiseAndSetIfChanged(ref useDefaultAppletMdFlashBinLocation, value);
            // }
        #endregion

        #region "Command Bindings"
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
            public void Configure()
            {
                string DropConfigurator = "https://drop.com/mechanical-keyboards/configurator";
                try
                {
                    System.Diagnostics.Process.Start(DropConfigurator);
                }
                catch
                {
                    if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(osWindows))
                    {
                        DropConfigurator = DropConfigurator.Replace("&", "^&");
                        System.Diagnostics.Process.Start(new ProcessStartInfo("cmd", $"/c start {DropConfigurator}") { CreateNoWindow = true });
                    }
                    else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(osLinux))
                    {
                        Process.Start("xdg-open", DropConfigurator);
                    }
                    else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(osMac))
                    {
                        Process.Start("open", DropConfigurator);
                    }
                    
                }
            }
            public void Settings()
            {
                var settingsWindow = new SettingsWindow();
                var SettingsWindowViewModel = new SettingsWindowViewModel();
                settingsWindow.DataContext = SettingsWindowViewModel;
                settingsWindow.Show();
            }
            public void DumpFirmware()
            {
                var dumpFirwareWindow = new DumpFirmwareWindow();
                dumpFirwareWindow.Show();
            }
            public void AssignDefaultLocations()
            {
                MdFlashLocationLinux = new DirectoryInfo(
                System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\linux\mdloader_linux"));
                MdFlashLocationMac = new DirectoryInfo(
                System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\mac\mdloader_mac"));
                MdFlashLocationWindows = new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\mdloader_windows.exe");
                DefaultProfileFolderDirectory = new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\profiles");
                DefaultAppletMdFlashBinLocation = new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\applet-mdflasher.bin");
                SettingsFileLocation = new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/settings.json");
            }
        #endregion
    }
}
