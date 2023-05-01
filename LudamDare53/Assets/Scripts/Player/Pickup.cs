using Assets.Scripts;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private string pickupTag = Tags.Collectible; // Configurable tag
    [SerializeField] private float pickupRadius = 3f; // Configurable pickup radius
    [SerializeField] private float pullRadius = 5f; // Configurable pull radius
    [SerializeField] private float pullSpeed = 1f; // Configurable pull speed

    private void Update()
    {
        // Find all objects with the pickupTag within pickupRadius
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(pickupTag))
            {
                // Calculate direction and distance to the object
                Vector3 direction = transform.position - collider.transform.position;
                float distance = direction.magnitude;

                // If the object is within the pull radius, pull it towards this object
                if (distance < pullRadius)
                {
                    float pullStrength = Mathf.Lerp(pullSpeed, 0f, distance / pullRadius); // Increase pull strength as distance decreases
                    collider.transform.position += direction.normalized * pullStrength * Time.deltaTime;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw pickup and pull radius gizmos in the Unity editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }
}
