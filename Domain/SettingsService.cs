using Newtonsoft.Json;
using System.IO;
using DropKeyboardConfigurator.Models;

namespace DropKeyboardConfigurator.Domain
{
    public class SettingsService 
    {
        // This service is solely for serializing the JSON for the settings file.
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