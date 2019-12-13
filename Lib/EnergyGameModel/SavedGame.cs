using System;

namespace EnergyGameModel
{

    [Serializable()]
    public class SavedGame
    {       
        public SavedGameHeader Header { get; set; }

        public SavedGame()
        {
        }

        public SavedGame(SavedGameHeader header)
        {
            Header = header;
        }

        // Лист ходов
    }

    [Serializable()]
    public class SavedGameHeader
    {
        public SavedGameHeader()
        {
        }

        public SavedGameHeader(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;
        }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }
    }
}
