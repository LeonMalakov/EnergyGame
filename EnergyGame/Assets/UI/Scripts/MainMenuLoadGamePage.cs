using System.Collections.Generic;
using UnityEngine;

namespace EnergyGame.UI
{
    public class MainMenuLoadGamePage : MainMenuPageBase
    {      
      //  [SerializeField] private GameObject savedGameButtonPrefab = null;

        private List<GameObject> savedGameButtons = new List<GameObject>();

        #region Override
        public override string Name => "LoadGame";

        protected override void OnPageInit()
        {
            RefreshSavesList();
        }
        #endregion


        #region LocalFunctions
        private void RefreshSavesList()
        {
            // create buttons
        }
        #endregion
    }
}