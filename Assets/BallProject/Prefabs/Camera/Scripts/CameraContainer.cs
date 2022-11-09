using UnityEngine;

public class CameraContainer : MonoBehaviour
{
    [SerializeField] private CameraFollowing _cameraFollowing;

    public CameraFollowing CameraFollowing => _cameraFollowing;
}
