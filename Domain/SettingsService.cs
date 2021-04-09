using Newtonsoft.Json;
using System.IO;
using DropKeyboardConfigurator.Models;

namespace DropKeyboardConfigurator.Domain
{
    public class SettingsService 
    {
        public SettingsModel LoadSettings(DirectoryInfo SettingsFileLocation)
        {
            try
            {
                return JsonConvert.DeserializeObject<SettingsModel>(File.ReadAllText(SettingsFileLocation.FullName));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}