using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using EnergyGameModel;
using UnityEngine;

namespace EnergyGame
{
    public class SaveLoader : ISaveLoader
    {
        private string SavingPlacePath => Application.streamingAssetsPath;
        private string SavesFolderPath => Path.Combine(SavingPlacePath, "Saves");
        private string SaveFileName => "save";
        private string SaveFileExt => "sav";
        private string SaveFileExtDot => '.' + SaveFileExt;

        // Application.persistentDataPath - documents
        // Application.streamingAssetsPath - streaming assets in game folder

        #region ISaveLoader
        public int GetSavesFilesCount()
        {
            if (!Directory.Exists(SavesFolderPath)) return 0;

            string[] filesPaths = Directory.GetFiles(SavesFolderPath);
            int count = 0;
            for (int i = 0;  i < filesPaths.Length; i++)
            {
                if (Path.GetExtension(filesPaths[i]).Equals(SaveFileExtDot))
                    count++;
            }
            return count;
        }

        public List<SavedGameItem> LoadSavesList()
        {
            if (!Directory.Exists(SavesFolderPath)) return null;

            List<SavedGameItem> savedGamesList = new List<SavedGameItem>();

            string[] filesPaths = Directory.GetFiles(SavesFolderPath);

            foreach (string s in filesPaths)
            {
                if (Path.GetExtension(s).Equals(SaveFileExtDot))
                    if (LoadSaveHeader(s, out SavedGameHeader savedGameHeader))
                        savedGamesList.Add(new SavedGameItem(savedGameHeader, s));
            }

            return savedGamesList;
        }

        public bool CreateSave(string name, Turn[] turns, out SavedGameItem savedGameItem)
        {
            if (!IsSavingFoldersExists())
                CreateSavingFolders();

            int saveID = GetFreeFileID();

            // Create save objects
            SavedGameHeader header = new SavedGameHeader(name, DateTime.Now);
            SavedGame savedGame = new SavedGame(turns);

            // Create file name
            StringBuilder fileNameStr = new StringBuilder(SaveFileName);
            fileNameStr.Append(saveID);
            fileNameStr.Append('.');
            fileNameStr.Append(SaveFileExt);

            string path = Path.Combine(SavesFolderPath, fileNameStr.ToString());

            FileStream stream = new FileStream(path, FileMode.Create);

            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, header);
            binary.Serialize(stream, savedGame);
            stream.Close();

            savedGameItem = new SavedGameItem(header, path);

            return true;
        }

        public bool LoadSave(string path, out SavedGameHeader savedGameHeader, out SavedGame savedGame)
        {
            savedGameHeader = null;
            savedGame = null;

            if (!IsSavingFoldersExists()) return false;

            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            savedGameHeader = (SavedGameHeader)binary.Deserialize(stream);
            savedGame = (SavedGame)binary.Deserialize(stream);
            stream.Close();

            return true;
        }

        public bool DeleteSave(string path)
        {       
            if (!File.Exists(path)) return false;

            if (!Path.GetExtension(path).Equals(SaveFileExtDot)) return false;

            File.Delete(path);

            return true;
        }

        #endregion

        public bool LoadSaveHeader(string path, out SavedGameHeader savedGameHeader)
        {
            savedGameHeader = null;

            if (!IsSavingFoldersExists()) return false;

            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            savedGameHeader = (SavedGameHeader)binary.Deserialize(stream);

            stream.Close();

            return true;
        }

        private bool IsSavingFoldersExists()
        {
            if (!Directory.Exists(SavingPlacePath))
                return false;

            if (!Directory.Exists(SavesFolderPath))
                return false;

            return true;
        }

        private void CreateSavingFolders()
        {
            if (!Directory.Exists(SavingPlacePath))
                Directory.CreateDirectory(SavingPlacePath);

            if (!Directory.Exists(SavesFolderPath))
                Directory.CreateDirectory(SavesFolderPath);
        }

        private int GetFreeFileID()
        {
            if (!Directory.Exists(SavesFolderPath)) return 0;

            string[] filesPaths = Directory.GetFiles(SavesFolderPath);
            List<int> reservedIDs = new List<int>();

            for (int i = 0; i < filesPaths.Length; i++)
            {
                string fileName = Path.GetFileName(filesPaths[i]);

                if (Path.GetExtension(fileName).Equals(SaveFileExtDot))
                {
                    if (int.TryParse(Path.GetFileNameWithoutExtension(fileName).Substring(SaveFileName.Length), out int fid))
                        reservedIDs.Add(fid);
                }
            }

            int id = -1;
            while (reservedIDs.Contains(++id)) ;

            return id;
        }
    }
}
