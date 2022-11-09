using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private CameraContainer _cameraContainer;
    [SerializeField] private RoadGenerator _roadGenerator;
    [SerializeField] private PlayTimer _playTimer;

    private Dictionary<Type, IState> _statesMap;
    private IState _currentState;
    private Ball _ball;

    [Inject]
    private void Construct(Ball ball)
    {
        _ball = ball;
    }    
    private void Awake()
    {
        InitStates();
        SetStateByDefault();
    }

    private void OnEnable()
    {
        _uI.StartMenu.StartButton.onClick.AddListener(SetPlayState);
        _uI.StartMenu.DifficaltySelectionButton.onClick.AddListener(SetDifficultySelectionState);
        _uI.FailMenu.DifficultySelectionButton.onClick.AddListener(SetDifficultySelectionState);
        _uI.FailMenu.RestartButton.onClick.AddListener(SetPlayState);
        _uI.DifficultySettingMenu.EasyButton.onClick.AddListener(SetStartState);
        _uI.DifficultySettingMenu.MediumButton.onClick.AddListener(SetStartState);
        _uI.DifficultySettingMenu.HardButton.onClick.AddListener(SetStartState);
        _ball.CollisionHandler.WallTaken += SetFailState;
    }

    private void OnDisable()
    {
        _uI.StartMenu.StartButton.onClick.RemoveListener(SetPlayState);
        _uI.StartMenu.DifficaltySelectionButton.onClick.RemoveListener(SetDifficultySelectionState);
        _uI.FailMenu.DifficultySelectionButton.onClick.RemoveListener(SetDifficultySelectionState);
        _uI.DifficultySettingMenu.EasyButton.onClick.RemoveListener(SetStartState);
        _uI.DifficultySettingMenu.MediumButton.onClick.RemoveListener(SetStartState);
        _uI.DifficultySettingMenu.HardButton.onClick.RemoveListener(SetStartState);
        _uI.FailMenu.RestartButton.onClick.RemoveListener(SetPlayState);
        _ball.CollisionHandler.WallTaken -= SetFailState;
    }

    private void Start()
    {
        SetStartState();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IState>
        {
            [typeof(InitialState)] = new InitialState(_ball),
            [typeof(StartState)] = new StartState(_uI, _roadGenerator),
            [typeof(DifficultySettingsState)] = new DifficultySettingsState(_uI, _ball),
            [typeof(PlayState)] = new PlayState(_uI, _ball, _playTimer),
            [typeof(FailState)] = new FailState(_uI, _ball, _roadGenerator, _playTimer)
        };
    }

    private void SetInitialState()
    {
        var state = GetState<InitialState>();
        SetState(state);
    }
    
    private void SetStartState()
    {
        var state = GetState<StartState>();
        SetState(state);
    }

    private void SetPlayState()
    {
        var state = GetState<PlayState>();
        SetState(state);
    }

    private void SetFailState()
    {
        var state = GetState<FailState>();
        SetState(state);
    }
    
    private void SetDifficultySelectionState()
    {
        var state = GetState<DifficultySettingsState>();
        SetState(state);
    }

    private void SetStateByDefault()
    {
        SetInitialState();
    }
    
    private void SetState(IState newState)
    {
        if(_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private IState GetState<T>() where T : IState
    {
        var type = typeof(T);
        return _statesMap[type];
    }
}
