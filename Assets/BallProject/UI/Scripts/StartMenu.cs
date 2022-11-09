using UnityEngine;
using UnityEngine.UI;

public class StartMenu : Menu
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _difficaltySelectionButton;

    public Button StartButton => _startButton;
    public Button DifficaltySelectionButton => _difficaltySelectionButton;
}
