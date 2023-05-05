using System.Collections;
using UnityEngine;

public class GameObjectIntervalSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject ObjectToSpawn;
    [SerializeField] protected float SpawnInterval = 2f;
    [SerializeField] protected float SpawnIntervalRange = 0f;
    [SerializeField] protected Vector2Int SpawnOffset = Vector2Int.zero;
    [SerializeField] protected bool shouldContinueSpawningObjects = true;
    [Min(1)]
    [SerializeField] protected int numberOfObectsToSpawnPerBurst = 1;
    [SerializeField] protected float secondsBetweenObjectSpawnsDuringBurst = 0.125f;

    protected virtual void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    protected virtual IEnumerator SpawnCoroutine()
    {
        while (shouldContinueSpawningObjects)
        {
            yield return new WaitForSeconds(GetSpawnInterval());
            for (int i = 0; i < numberOfObectsToSpawnPerBurst; i++)
            {
                yield return new WaitForSeconds(secondsBetweenObjectSpawnsDuringBurst);
                SpawnObject();
            }
        }
    }

    protected virtual void SpawnObject()
    {
        Instantiate(ObjectToSpawn, GetSpawnPosition(), Quaternion.identity);
    }

    protected virtual float GetSpawnInterval()
    {
        return Random.Range(SpawnInterval - SpawnIntervalRange, SpawnInterval + SpawnIntervalRange);
    }

    protected virtual Vector3 GetSpawnPosition()
    {
        return transform.position + new Vector3(SpawnOffset.x, SpawnOffset.y, 0);
    }
}
