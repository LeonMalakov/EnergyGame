using System.Collections.Generic;

using EnergyGameModel;

namespace EnergyGame
{
    public class SavingManager
    {
        private ISaveLoader loader;

        private List<SavedGameItem> savedGamesList = new List<SavedGameItem>();

        public SavedGameHeader[] GetSavedGamesHeaders()
        {
            if (savedGamesList.Count != loader.GetSavesFilesCount())
                LoadSavesList();

            SavedGameHeader[] headers = new SavedGameHeader[savedGamesList.Count];
            for (int i = 0; i < savedGamesList.Count; i++)
                headers[i] = savedGamesList[i].Header;

            return headers;
        }

        public SavingManager(ISaveLoader loader)
        {
            this.loader = loader;
        }

        public void LoadSavesList()
        {
            savedGamesList = loader.LoadSavesList();
        }

        public void CreateSave(string name, Turn[] turns)
        {
            if (loader.CreateSave(name, turns, out SavedGameItem savedGameItem))
                savedGamesList.Add(savedGameItem);
        }

        public bool LoadSave(int index, out SavedGameHeader header, out SavedGame savedGame)
        {
            if (savedGamesList == null || savedGamesList.Count == 0)
            {
                header = null;
                savedGame = null;
                return false;
            }

            if (!loader.LoadSave(savedGamesList[index].Path, out header, out savedGame))
                return false;

            return true;
        }

        public bool DeleteSave(int index)
        {
            if (savedGamesList == null || savedGamesList.Count == 0) return false;

            loader.DeleteSave(savedGamesList[index].Path);

            return true;
        }
    }
}
