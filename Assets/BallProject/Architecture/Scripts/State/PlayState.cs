public class PlayState : IState
{
    private UI _uI;
    private Ball _ball;
    private PlayTimer _playTimer;
    
    public PlayState(UI uI, Ball ball, PlayTimer playTimer)
    {
        _uI = uI;
        _ball = ball;
        _playTimer = playTimer;
    }

    public void Enter()
    {
        _ball.EnableCollider();
        _playTimer.Enable();
        _uI.PlayMenu.Show();
        _ball.Mover.Enable();
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
        _playTimer.Disable();
    }
}
