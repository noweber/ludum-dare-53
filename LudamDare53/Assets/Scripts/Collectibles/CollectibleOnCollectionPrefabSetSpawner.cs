using Assets.Scripts.Spawning;
using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public sealed class CollectibleOnCollectionPrefabSetSpawner : OnDemandPrefabSetSpawner
    {
        private ICollectible collectible;

        void Start()
        {
            collectible = GetComponent<ICollectible>();
            if (collectible != null)
            {
                collectible.OnCollection += SpawnCollectibleSfx;
            }
            else
            {
                Debug.LogError("daf");
            }
        }

        private void SpawnCollectibleSfx()
        {
            SpawnPrefabs();
            Destroy(gameObject);
        }
    }
}
