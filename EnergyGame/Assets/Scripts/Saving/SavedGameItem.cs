using EnergyGameModel;

namespace EnergyGame
{
    public class SavedGameItem
    {
        public SavedGameItem(SavedGameHeader header, string path)
        {
            Header = header;
            Path = path;
        }

        public SavedGameHeader Header { get; set; }

        public string Path { get; set; }
    }
}
