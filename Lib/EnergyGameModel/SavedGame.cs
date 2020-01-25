using System;

namespace EnergyGameModel
{

    [Serializable()]
    public class SavedGame
    {
        public Turn[] Turns { get; set; }

        public SavedGame()
        {
        }

        public SavedGame(Turn[] turns)
        {
            Turns = turns;
        }
    }

    [Serializable()]
    public class SavedGameHeader
    {
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public SavedGameHeader()
        {
        }

        public SavedGameHeader(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;
        }
    }
}
