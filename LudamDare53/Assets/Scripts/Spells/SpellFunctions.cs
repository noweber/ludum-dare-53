using UnityEngine;

namespace Assets.Scripts.Spells
{
    public static class SpellFunctions
    {
        public static GameObject GetNearestEnemy(GameObject gameObject)
        {
            var enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy);
            float closestDistance = float.MaxValue;
            GameObject nearestEnemy = null;
            foreach (var enemy in enemies)
            {
                float currentDistance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
                if (currentDistance < closestDistance)
                {
                    nearestEnemy = enemy;
                    closestDistance = currentDistance;
                }
            }
            return nearestEnemy;
        }
    }
}
