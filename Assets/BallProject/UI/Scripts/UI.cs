using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private StartMenu startMenu;
    [SerializeField] private DifficultySettingMenu _difficultySettingMenu;
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private FailMenu _failMenu;
    
    public StartMenu StartMenu => startMenu;
    public DifficultySettingMenu DifficultySettingMenu => _difficultySettingMenu;
    public PlayMenu PlayMenu => _playMenu;
    public FailMenu FailMenu => _failMenu;
}
