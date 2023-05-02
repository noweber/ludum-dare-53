using UnityEngine;

public class GameObjectLinearBurstSpawner : GameObjectIntervalSpawner
{
    [SerializeField] protected int numberOfObjectsToSpawn;
    [SerializeField] protected float spawnSpeedMultiplier = 0.9f;
    [SerializeField] protected int numberOfObjectsSpawned = 0;
    [SerializeField] private float originalSpawnInterval;

    protected override void Start()
    {
        base.Start();
        originalSpawnInterval = SpawnInterval;
    }

    protected override float GetSpawnInterval()
    {
        numberOfObjectsSpawned++;
        if (IsSpawnCountReached())
        {
            numberOfObjectsSpawned = 0;
            SpawnInterval = originalSpawnInterval;
            return originalSpawnInterval;
        }

        SpawnInterval *= spawnSpeedMultiplier;
        return SpawnInterval;
    }

    public virtual bool IsSpawnCountReached()
    {
        return numberOfObjectsSpawned >= numberOfObjectsToSpawn;
    }
}
