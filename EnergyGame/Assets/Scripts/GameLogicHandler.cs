using UnityEngine;
using EnergyGameModel;

namespace EnergyGame
{
    public class GameLogicHandler : MonoBehaviour
    {
        private GameLogic _gameLogic;

        public GameLogic GameLogic
        {
            get
            {
                if (_gameLogic == null)
                    _gameLogic = new GameLogic();
                return _gameLogic;
            }
        }

    }
}