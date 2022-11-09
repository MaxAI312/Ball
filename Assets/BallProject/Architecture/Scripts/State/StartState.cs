public class StartState : IState
{
    private UI _uI;
    private RoadGenerator _roadGenerator;
    
    public StartState(UI uI, RoadGenerator roadGenerator)
    {
        _uI = uI;
        _roadGenerator = roadGenerator;
    }

    public void Enter()
    {
        _uI.StartMenu.Show();
        _roadGenerator.Reset();
    }

    public void Exit()
    {
        _uI.StartMenu.Hide();
    }
}
