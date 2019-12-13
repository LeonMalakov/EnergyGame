using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnergyGame
{
    public class GameManager : Singleton<GameManager>
    {
        #region Readonly
        private readonly string MainMenuSceneName = "MainMenuScene";
        private readonly string GameSceneName = "GameScene";
        #endregion


        public GameManager()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }


        #region Public
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(GameSceneName, LoadSceneMode.Single);
        }
        #endregion


        #region LocalFunctions
        private void SetupGameLogic()
        {
            // Start new / Load 
            if(SceneRegistrator.Current.GetObject(out GameLogicHandler handler))
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
