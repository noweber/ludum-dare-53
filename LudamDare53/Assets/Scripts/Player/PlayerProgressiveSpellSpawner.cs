using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public sealed class PlayerProgressiveSpellSpawner : GameObjectIntervalSpawner
    {
        [SerializeField] LevelUpController levelController;

        private int lastKnownLevel = 1;

        private void LateUpdate()
        {
            if (levelController == null)
            {
                levelController = GetComponent<LevelUpController>();
            }
            if (levelController != null && lastKnownLevel != levelController.Level)
            {
                lastKnownLevel = levelController.Level;
                AddNumberOfProjectilesToSpawn(1);
            }
        }

        protected override void SpawnObject()
        {
            var enemyTarget = SpellFunctions.GetNearestEnemy(gameObject);
            Instantiate(ObjectToSpawn, GetSpawnPosition(), Quaternion.identity).GetComponent<Rigidbody2dTargetChaser>().Initialize(enemyTarget, false);
        }

        private void AddNumberOfProjectilesToSpawn(int value)
        {
            base.numberOfObectsToSpawnPerBurst += value;
        }
    }
}
