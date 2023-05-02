using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public sealed class PlayerProgressiveSpellSpawner : GameObjectLinearBurstSpawner
    {
        [SerializeField] LevelUpController levelController;

        private int lastKnownLevel = 0;

        private void LateUpdate()
        {
            if(levelController == null)
            {
                levelController = GetComponent<LevelUpController>();
            }
            if(levelController != null && lastKnownLevel != levelController.Level)
            {
                lastKnownLevel = levelController.Level;
                AddNumberOfProjectilesToSpawn(1);
                ReduceProjectileSpawnRate();
            }
        }

        protected override void SpawnObject()
        {
            var enemyTarget = SpellFunctions.GetNearestEnemy(gameObject);
            Instantiate(ObjectToSpawn, GetSpawnPosition(), Quaternion.identity).GetComponent<Rigidbody2dTargetChaser>().Initialize(enemyTarget, false);
        }

        private void AddNumberOfProjectilesToSpawn(int value)
        {
            base.numberOfObjectsToSpawn += value;
        }

        private void ReduceProjectileSpawnRate()
        {
            base.spawnSpeedMultiplier *= spawnSpeedMultiplier;
        }
    }
}
