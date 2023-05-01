using UnityEngine;

namespace Assets.Scripts.Spells
{
    public class TargetNearestEnemyLinearBurstSpellSpawner : GameObjectLinearBurstSpawner
    {
        protected override void SpawnObject()
        {
            var enemyTarget = SpellFunctions.GetNearestEnemy(gameObject);
            Instantiate(ObjectToSpawn, GetSpawnPosition(), Quaternion.identity).GetComponent<Rigidbody2dTargetChaser>().Initialize(enemyTarget, false);
        }
    }
}
