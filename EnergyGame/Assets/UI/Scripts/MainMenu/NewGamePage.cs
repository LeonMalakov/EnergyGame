namespace EnergyGame.UI.MainMenu
{
    public class NewGamePage : PageBase
    {

        #region Override
        public override string Name => "NewGame";
        #endregion

        #region Buttons 
        public void Btn_Start()
        {
            GameManager.Instance.LoadGameScene();
        }
        #endregion

    }
}
