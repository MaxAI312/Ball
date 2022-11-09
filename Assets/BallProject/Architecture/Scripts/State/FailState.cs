public class FailState : IState
{
    private UI _uI;
    private Ball _ball;
    private RoadGenerator _roadGenerator;
    private PlayTimer _playTimer;
    
    public FailState(UI uI, Ball ball, RoadGenerator roadGenerator, PlayTimer playTimer)
    {
        _uI = uI;
        _ball = ball;
        _roadGenerator = roadGenerator;
        _playTimer = playTimer;
    }

    public void Enter()
    {
        Data data = Storage.Load();
        data.AttemptsNumber += 1;
        Storage.Save(data);

        _uI.FailMenu.SetGameAttemptCounterText(data.AttemptsNumber);
        _uI.FailMenu.SetDurationLastAttemptText(_playTimer.ElapsedTime);
        _uI.FailMenu.Show();
        _ball.Mover.Disable();
        _ball.ResetPosition();
        _roadGenerator.Reset();
    }

    public void Exit()
    {
        _uI.FailMenu.Hide();
    }
}
