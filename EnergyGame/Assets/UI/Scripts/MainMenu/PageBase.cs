using UnityEngine;

namespace EnergyGame.UI.MainMenu
{
    public abstract class PageBase : MonoBehaviour
    {

        private bool firstOpen = true;

        private GameObject pageObject;

        #region Public
        public abstract string Name { get; } // => "PageBase"

        public void Open()
        {
            if (firstOpen)
            {
                Init();
                firstOpen = false;
            }

            OnPageOpening();

            pageObject.SetActive(true);
        }

        public void Close()
        {
            pageObject.SetActive(false);

            OnPageClosing();
        }
        #endregion

        #region VirtualEvents
        protected virtual void OnPageOpening() { }

        protected virtual void OnPageClosing() { }

        /// <summary>
        /// First open of page
        /// </summary>
        protected virtual void OnPageInit() { }
        #endregion


        #region LocalFunctions
        private void Init()
        {
            pageObject = transform.GetChild(0).gameObject;

            OnPageInit();
        }

        #endregion
    }
}
