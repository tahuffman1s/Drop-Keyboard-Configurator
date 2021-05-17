namespace DropKeyboardConfigurator.Models
{
    public class SettingsModel 
    {
        // This model is for holding the settings after they've been serialized by the JSON.
        // To add a new setting all you have to do is add the type and name here, then you
        // add it to the settings file and give it a value there.
        // To access the data just access the model and the value on the model.
        // Values in this model are meant to be bound to different places.
        // Binding can be done by doing {Binding SettingsModelName.Value} in the XAML.
        public string Background { get; set; }
        public string ButtonBackground { get; set; }
        public string ButtonBorder { get; set; }
        public string FileBoxBackground { get; set; }
        public string FileBoxBorder { get; set; }
        public string MenuBackground { get; set; }
        public string MenuAccent { get; set; }
        public string LabelColor { get; set; }
        public string SettingsTextColor { get; set; }
        public string BottomLabelBorder { get; set; }
        public string BottomLabelBackground { get; set; }
        public bool UseDefaultProfileFolderLocation { get; set; }
        public bool UseDefaultMDFlashLocations { get; set; }
        public bool UseDefaultAppletMdFlashBinLocation { get; set; }
        public string ProfileFolderLocation { get; set; }
        public string MDFlashLocation { get; set; }
        public string AppletMdFlashBinLocation { get; set; }
    }
}