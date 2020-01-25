using System.Collections.Generic;

using EnergyGameModel;

using UnityEngine;

namespace EnergyGame.UI.MainMenu
{
    public class LoadGamePage : PageBase
    {
        [SerializeField] private GameObject savedGameButtonPrefab = null;

        [SerializeField] private Transform savedGamesListAnchor = null;

        private List<LoadGamePage_ListButton> savedGameButtons = new List<LoadGamePage_ListButton>();

        private SavedGameHeader[] saveGamesHeaders;

        private int selectedIndex = -1;

        #region Override
        public override string Name => "LoadGame";

        protected override void OnPageOpening()
        {
            RefreshSavesList();
        }
        #endregion


        #region Buttons
        public void Btn_SavedGame(int index)
        {
            selectedIndex = index;
        }

        public void Btn_LoadGame()
        {
            if (selectedIndex == -1) return;

            GameManager.Instance.LoadGame(selectedIndex);
        }

        public void Btn_DeleteSave()
        {
            if (selectedIndex == -1) return;

            GameManager.Instance.DeleteSave(selectedIndex);

            RefreshSavesList();
        }
        #endregion

        #region LocalFunctions
        private void RefreshSavesList()
        {
            Debug.Log("1. : " + saveGamesHeaders?.Length);
            saveGamesHeaders = GameManager.Instance.GetSavesList();
            Debug.Log("2. : " + saveGamesHeaders?.Length);

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (saveGamesHeaders == null || saveGamesHeaders.Length == 0)
            {
                for (int i = 0; i < savedGameButtons.Count; i++)
                    savedGameButtons[i].Remove();

                savedGameButtons.Clear();

                return;
            }

            if (savedGameButtons.Count < saveGamesHeaders.Length)
            {
                int t = saveGamesHeaders.Length - savedGameButtons.Count;
                for (int i = 0; i < t; i++)
                    savedGameButtons.Add(Instantiate(savedGameButtonPrefab, savedGamesListAnchor)
                        .GetComponent<LoadGamePage_ListButton>());
            }
            else if (savedGameButtons.Count > saveGamesHeaders.Length)
            {
                int t = savedGameButtons.Count - saveGamesHeaders.Length;
                for (int i = 0; i < t; i++)
                {
                    savedGameButtons[0].Remove();
                    savedGameButtons.RemoveAt(0);
                }
            }

            for (int i = 0; i < saveGamesHeaders.Length; i++)
            {
                savedGameButtons[i].Set(saveGamesHeaders[i].Name, saveGamesHeaders[i].DateTime, i, Btn_SavedGame);
            }
        }
        #endregion
    }
}
