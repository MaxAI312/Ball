using UnityEngine;

[CreateAssetMenu(menuName = "LevelSettings", fileName = "NewSettings")]
public class SpeedSettings : ScriptableObject
{
    [SerializeField] private float _easySpeed;
    [SerializeField] private float _mediumSpeed;
    [SerializeField] private float _hardSpeed;

    public float EasySpeed => _easySpeed;
    public float MediumSpeed => _mediumSpeed;
    public float HardSpeed => _hardSpeed;
}
