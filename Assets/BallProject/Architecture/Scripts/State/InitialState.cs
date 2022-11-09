public class InitialState : IState
{
    private Ball _ball;
    
    public InitialState(Ball ball)
    {
        _ball = ball;
    }

    public void Enter()
    {
        _ball.Mover.Disable();
        _ball.ResetPosition();
    }

    public void Exit()
    {
    }
}
