namespace DropKeyboardConfigurator.Models
{
    public class SettingsModel 
    {
        public string Background { get; set; }
        public string ButtonBackground { get; set; }
        public string ButtonBorder { get; set; }
        public string FileBoxBackground { get; set; }
        public string FileBoxBorder { get; set; }
        public string MenuBackground { get; set; }
        public string MenuAccent { get; set; }
        public string LabelColor { get; set; }
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