
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public sealed class TargetNearestEnemyIntervalSpellSpawner : GameObjectIntervalSpawner
    {
        protected override void SpawnObject()
        {
            var enemyTarget = SpellFunctions.GetNearestEnemy(gameObject);
            if (enemyTarget != null)
            {
                Instantiate(ObjectToSpawn, GetSpawnPosition(), Quaternion.identity).GetComponent<Rigidbody2dTargetChaser>().Initialize(enemyTarget, false);
            }
        }
    }
}
