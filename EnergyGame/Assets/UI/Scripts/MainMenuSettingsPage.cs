using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnergyGame.UI
{
    public class MainMenuSettingsPage : MainMenuPageBase
    {

       // [SerializeField] private Dropdown screenResolutionDropdown = null;

      //  [SerializeField] private Toggle fullscreenToggle = null;


        #region Override
        public override string Name => "Settings";

        protected override void OnPageOpening()
        {
            UpdateSettingsView();
        }

        protected override void OnPageClosing()
        {

        }

        protected override void OnPageInit()
        {
        }
        #endregion


        #region Buttons
        public void Btn_Apply()
        {
            ApplySettings();
        }
        #endregion

        #region LocalFunctions
        private void UpdateSettingsView()
        {

        }

        private void ApplySettings()
        {
        }
        #endregion
    }
}