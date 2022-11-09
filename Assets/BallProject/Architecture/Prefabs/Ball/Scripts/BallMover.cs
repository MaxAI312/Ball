using UnityEngine;

public class BallMover : MonoBehaviour
{
    private const float EasySpeed = 5f;
    private const float MediumSpeed = 7.5f;
    private const float HardSpeed = 10f;

    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _speedStep;
    [SerializeField] private float _timeBeforeAcceleration;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    
    private Vector3 _verticalDirection = new Vector3();
    private float _elapsedTime = 0f;

    private void OnEnable()
    {
        _elapsedTime = 0f;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _timeBeforeAcceleration)
        {
            _verticalSpeed += _speedStep;
            _elapsedTime = 0;
        }
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.forward * _forwardSpeed * Time.deltaTime);
        transform.Translate( _verticalDirection * _verticalSpeed * Time.deltaTime);

        var currentPositionY = Mathf.Clamp(transform.position.y, _minPositionY, _maxPositionY);
        transform.position = new Vector3(transform.position.x, currentPositionY, transform.position.z);
    }

    public void MoveUp()
    {
        _verticalDirection = transform.up;
    }
    
    public void MoveDown()
    {
        _verticalDirection = -transform.up;
    }

    public void Enable()
    {
        enabled = true;
        MoveDown();
    }

    public void Disable()
    {
        enabled = false;
    }
    
    public void SetEasySpeed()
    {
        _forwardSpeed = EasySpeed;
    }
    
    public void SetMediumSpeed()
    {
        _forwardSpeed = MediumSpeed;
    }
    
    public void SetHardSpeed()
    {
        _forwardSpeed = HardSpeed;
    }
}