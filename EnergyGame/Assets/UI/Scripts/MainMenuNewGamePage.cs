namespace EnergyGame.UI
{
    public class MainMenuNewGamePage : MainMenuPageBase
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