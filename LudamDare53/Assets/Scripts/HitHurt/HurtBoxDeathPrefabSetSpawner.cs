using Assets.Scripts.Spawning;
using UnityEngine;

namespace Assets.Scripts.HitHurt
{
    public sealed class HurtBoxDeathPrefabSetSpawner : OnDemandPrefabSetSpawner
    {
        private IHurtBox hurtBox;

        void Start()
        {
            hurtBox = GetComponent<HurtBox>();
            if (hurtBox != null)
            {
                hurtBox.HitPointsAreZero += Die;
            }
        }

        private void Die()
        {
            SpawnPrefabs();
            Destroy(gameObject);
        }
    }
}
