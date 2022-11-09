using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : Menu
{
    [SerializeField] private Button _upButton;

    public Button UpButton => _upButton;
}
