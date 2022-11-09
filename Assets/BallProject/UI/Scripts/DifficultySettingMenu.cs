using UnityEngine;
using UnityEngine.UI;

public class DifficultySettingMenu : Menu
{
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _mediumButton;
    [SerializeField] private Button _hardButton;
    
    public Button EasyButton => _easyButton;
    public Button MediumButton => _mediumButton;
    public Button HardButton => _hardButton;
}
