using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadGenerator : ObjectPool
{
    [SerializeField] private List<GameObject> _roads;
    [SerializeField] private int _maxCountRoad;
    [SerializeField] private float _distanceBetweenRoad;

    private GameObject _lastRoad;
    private float _disablePointZ = -20f;
    private float _elapsedTime;
    private Ball _ball;

    [Inject]
    private void Construct(Ball ball)
    {
        _ball = ball;
    }
    
    private void Start()
    {
        Initialize(_roads);
    }

    private void FixedUpdate()
    {
        int numberOfActiveRoads = GetNumberOfActiveRoads();

        if (numberOfActiveRoads < _maxCountRoad)
        {
            if (TryGetObject(out GameObject road))
            {
                if (numberOfActiveRoads == 0 )
                {
                    SpawnRoad(road, Vector3.zero);
                    _lastRoad = road;
                }
                else
                {
                    if (Vector3.Distance(_ball.transform.position, _lastRoad.transform.position) > DistanceBetweenPlayerAndItem)
                    {
                        SpawnRoad(road, _lastRoad.transform.position + new Vector3(transform.position.x, transform.position.y, _distanceBetweenRoad));
                        _lastRoad = road;
                    }
                }
            }
        }
        DisableObjectAbroadScreen(_disablePointZ);
    }

    private void SpawnRoad(GameObject road, Vector3 spawnPoint)
    {
        road.SetActive(true);
        road.transform.position = spawnPoint;
    }
}