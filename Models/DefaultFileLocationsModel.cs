using System.Reflection;
using System.IO;

namespace DropKeyboardConfigurator.Models
{
    public class DefaultFileLocationsModel
    {
        // This model retrives the default file locations for Linux/Mac/Windows. It also gets the default settings file location, and the default_settings.json file.
        public DirectoryInfo MdFlashLocationLinux
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\linux\mdloader_linux"));
        }
        public DirectoryInfo MdFlashLocationMac
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\mac\mdloader_mac"));
        }
        public DirectoryInfo MdFlashLocationWindows
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\mdloader_windows.exe");
        }
        public DirectoryInfo DefaultProfileFolderDirectory
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\profiles");
        }
        public DirectoryInfo DefaultAppletMdFlashBinLocation
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\applet-mdflasher.bin");
        }
        public DirectoryInfo SettingsFileLocation
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/settings.json");
        }
        public DirectoryInfo DefaultSettingFileLocation
        {
            get => new DirectoryInfo(
                System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"/settings_default.json");
        }
    }
}