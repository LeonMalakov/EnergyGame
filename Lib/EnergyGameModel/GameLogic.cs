using System;
using System.Collections.Generic;

namespace EnergyGameModel
{
    public class GameLogic
    {
        private List<IPlayable> players;

        private List<IEnergyObject> energyObjects;

        private int currentTurn;
        
        public bool IsStarted { get; private set; }

        public GameLogic()
        {
            players = new List<IPlayable>();
            energyObjects = new List<IEnergyObject>();
        }

        public void StartNewGame()
        {
            if (IsStarted) return;

            IsStarted = true;
        }

        public void LoadGame(SavedGame save)
        {
            if (IsStarted) return;

            IsStarted = true;
        }

        internal void NextTurn()
        {
            if (players.Count == 0) return;

            players[currentTurn].EndTurn();

            if (++currentTurn >= players.Count) currentTurn = 0;

            players[currentTurn].StartTurn();
        }
    }
}
