public class DifficultySettingsState : IState
{
    private UI _uI;
    private Ball _ball;
    
    public DifficultySettingsState(UI uI, Ball ball)
    {
        _uI = uI;
        _ball = ball;
    }

    public void Enter()
    {
        _uI.DifficultySettingMenu.Show();
        _uI.DifficultySettingMenu.EasyButton.onClick.AddListener(_ball.Mover.SetEasySpeed);
        _uI.DifficultySettingMenu.MediumButton.onClick.AddListener(_ball.Mover.SetMediumSpeed);
        _uI.DifficultySettingMenu.HardButton.onClick.AddListener(_ball.Mover.SetHardSpeed);
    }

    public void Exit()
    {
        _uI.DifficultySettingMenu.EasyButton.onClick.RemoveListener(_ball.Mover.SetEasySpeed);
        _uI.DifficultySettingMenu.MediumButton.onClick.RemoveListener(_ball.Mover.SetMediumSpeed);
        _uI.DifficultySettingMenu.HardButton.onClick.RemoveListener(_ball.Mover.SetHardSpeed);
        _uI.DifficultySettingMenu.Hide();
    }
}
