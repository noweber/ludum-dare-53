using UnityEngine;

namespace Assets.Scripts.Spawning
{
    public class OnDemandPrefabSetSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] PrefabsWithAChanceToSpawn;

        [Range(0, 1)]
        [SerializeField] private float PercentChanceToSpawnEachPrefab = 0.5f;

        [Range(1, int.MaxValue)]
        [SerializeField] private int MaxSpawnCountPerPrefab = 1;

        [SerializeField] private GameObject[] PrefabsWhichAlwaysSpawn;

        public void SpawnPrefabs()
        {
            // Instantiate the first set of prefabs with a chance and a random number of times
            if (PrefabsWithAChanceToSpawn != null && PrefabsWithAChanceToSpawn.Length > 0)
            {
                foreach (GameObject prefab in PrefabsWithAChanceToSpawn)
                {
                    if (MaxSpawnCountPerPrefab >= 1 && prefab != null && Random.value <= PercentChanceToSpawnEachPrefab)
                    {
                        int spawnCount = Random.Range(1, MaxSpawnCountPerPrefab + 1);
                        for (int i = 0; i < spawnCount; i++)
                        {
                            Instantiate(prefab, transform.position, transform.rotation);
                        }
                    }
                }


            }

            // Instantiate the second set of prefabs once
            if (PrefabsWhichAlwaysSpawn != null && PrefabsWhichAlwaysSpawn.Length > 0)
            {
                foreach (GameObject prefab in PrefabsWhichAlwaysSpawn)
                {
                    if (prefab != null)
                    {
                        Instantiate(prefab, transform.position, transform.rotation);
                    }
                }
            }
        }
    }
}
