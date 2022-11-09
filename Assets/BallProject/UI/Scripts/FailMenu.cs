using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FailMenu : Menu
{
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private TMP_Text _durationLastAttemptText;
    [SerializeField] private TMP_Text _gameAttemptCounterText;
    [SerializeField] private Button _difficultySelectionButton;
    [SerializeField] private Button _restartButton;

    public TMP_Text GameOverText => _gameOverText;
    public TMP_Text DurationLastAttemptText => _durationLastAttemptText;
    public TMP_Text GameAttemptCounterText => _gameAttemptCounterText;
    public Button DifficultySelectionButton => _difficultySelectionButton;
    public Button RestartButton => _restartButton;

    public void SetDurationLastAttemptText(float value)
    {
        _durationLastAttemptText.text = "Продолжительность попытки: " + value.ToString("0.0");
    }
    
    public void SetGameAttemptCounterText(int value)
    {
        _gameAttemptCounterText.text = "Количество попыток: " + value;
    } 
}
