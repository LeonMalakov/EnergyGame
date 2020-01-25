using System.Collections.Generic;

using EnergyGameModel;

namespace EnergyGame
{
    public interface ISaveLoader
    {
        int GetSavesFilesCount();

        List<SavedGameItem> LoadSavesList();

        bool CreateSave(string name, Turn[] turns, out SavedGameItem savedGameItem);

        bool LoadSave(string path, out SavedGameHeader savedGameHeader, out SavedGame savedGame);

        bool DeleteSave(string path);

    }
}
