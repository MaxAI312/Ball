using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public Transform StartPoint;
    public GameObject BallPrefab;
    
    public override void InstallBindings()
    {
        Ball ball = Container
            .InstantiatePrefabForComponent<Ball>(BallPrefab, StartPoint.position, Quaternion.identity, null);

        Container
            .Bind<Ball>()
            .FromInstance(ball)
            .AsSingle();
    }
}