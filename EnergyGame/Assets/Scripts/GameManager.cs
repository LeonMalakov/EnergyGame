using EnergyGameModel;

using UnityEngine.SceneManagement;

namespace EnergyGame
{
    public class GameManager : Singleton<GameManager>
    {
        #region Readonly
        private readonly string MainMenuSceneName = "MainMenuScene";
        private readonly string GameSceneName = "GameScene";
        #endregion

        #region Toolbox
        private SavingManager _savingManager;
        private SavingManager SavingManager
        {
            get
            {
                if (_savingManager == null)
                    _savingManager = new SavingManager(new SaveLoader());

                return _savingManager;
            }
        }
        #endregion


        private SavedGame currentSavedGame;

        public GameManager()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }


        #region Public
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
        }

        public void LoadGameScene(SavedGame savedGame = null)
        {
            currentSavedGame = savedGame;
            SceneManager.LoadScene(GameSceneName, LoadSceneMode.Single);
        }

        public SavedGameHeader[] GetSavesList()
        {
            return SavingManager.GetSavedGamesHeaders();
        }

        public bool SaveGame(string name)
        {
            if (!SceneRegistrator.Current.GetObject(out GameLogicHandler handler)) return false;

            Turn[] turns = handler.GameLogic.GetTurns();

            if (turns == null) return false;

            SavingManager.CreateSave(name, turns);

            return true;
        }

        public bool LoadGame(int index)
        {
            if (!SavingManager.LoadSave(index, out SavedGameHeader header, out SavedGame savedGame)) return false;

            // Load game         
            LoadGameScene(savedGame);

            return true;
        }

        public bool DeleteSave(int index)
        {
            return SavingManager.DeleteSave(index);
        }
        #endregion


        #region LocalFunctions
        private void SetupGameLogic()
        {
            // Start new / Load 
            if (!SceneRegistrator.Current.GetObject(out GameLogicHandler handler)) return;

            if (currentSavedGame != null)
                handler.GameLogic.LoadGame(currentSavedGame);
            else
                handler.GameLogic.StartNewGame();
        }
        #endregion

        #region Events
        private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
        {
            if (scene.name == GameSceneName)
                SetupGameLogic();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        #endregion

    }
}
