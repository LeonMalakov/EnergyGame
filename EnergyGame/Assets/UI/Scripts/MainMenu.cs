using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnergyGame.UI
{
    public class MainMenu : MonoBehaviour
    {
        [System.Serializable]
        class Page
        {
            public MainMenuPageBase page;
            public Button button;

            public Page(MainMenuPageBase page, Button button)
            {
                this.page = page;
                this.button = button;
            }

            public string Name => page?.Name;

            public void Open()
            {
                page.Open();
                if (button != null) button.interactable = false;
            }

            public void Close()
            {
                page.Close();
                if (button != null) button.interactable = true;
            }
        }

        [SerializeField] private Page[] _pages;

        private Dictionary<string, Page> pages = new Dictionary<string, Page>();

        private string currentPageName = string.Empty;

        private void Start()
        {
            for (int i = 0; i < _pages.Length; i++)
            {
                if (_pages[i].page == null && !pages.ContainsKey(_pages[i].Name)) continue;

                string name = _pages[i].Name;
                pages.Add(name, _pages[i]);
                _pages[i].button.onClick.AddListener(delegate { Btn_PageButtonClicked(name); });
            }
            _pages = null;
        }

        #region Buttons
        public void Btn_PageButtonClicked(string pageName)
        {
            OpenPage(pageName);
        }

        public void Btn_Quit()
        {
            Application.Quit();
        }

        #endregion


        #region LocalFunctions
        private void OpenPage(string pageName)
        {
            if (currentPageName != string.Empty)
                pages[currentPageName].Close();


            if (pages.ContainsKey(pageName))
            {
                currentPageName = pageName;
            }
            else
            {
                currentPageName = string.Empty;
                return;
            }

            pages[currentPageName].Open();
        }
        #endregion
    }
}