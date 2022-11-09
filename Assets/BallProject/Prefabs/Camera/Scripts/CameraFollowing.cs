using UnityEngine;
using Zenject;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [Space(15)]
    [SerializeField] private float _height;
    [SerializeField] private float _distance;

    private Vector3 _targetPosition;
    private Transform _target;
    
    [Inject]
    private void Construct(Ball ball)
    {
        _target = ball.transform;
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        _targetPosition = _target.position;
        _targetPosition -= _target.forward * _distance;
        _targetPosition += Vector3.up * _height;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}