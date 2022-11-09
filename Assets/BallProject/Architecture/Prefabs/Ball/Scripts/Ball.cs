using UnityEngine;

[SelectionBase]
public class Ball : MonoBehaviour
{
    [SerializeField] private BallMover _mover;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Collider _collider;

    public BallMover Mover => _mover;
    public CollisionHandler CollisionHandler => _collisionHandler;
    public Vector3 StartPosition => _startPosition;

    private void OnEnable()
    {
        _collisionHandler.WallTaken += DisableCollider;
    }
    
    private void OnDisable()
    {
        _collisionHandler.WallTaken -= DisableCollider;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
    }

    public void DisableCollider()
    {
        _collider.enabled = false;
    }

    public void EnableCollider()
    {
        _collider.enabled = true;
    }
}