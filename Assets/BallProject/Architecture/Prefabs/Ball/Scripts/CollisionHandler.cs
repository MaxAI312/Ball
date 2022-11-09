using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var wall = other.GetComponent<Wall>();

        if (wall)
        {
            WallTaken?.Invoke();
        }
    }

    public event Action WallTaken;
}
