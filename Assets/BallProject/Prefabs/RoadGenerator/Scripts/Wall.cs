using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, GetPositionY(), transform.position.z);
    }

    private float GetPositionY()
    {
        return Random.Range(_minPositionY, _maxPositionY);
    }
}
