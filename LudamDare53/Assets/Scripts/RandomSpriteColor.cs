using UnityEngine;

public class RandomSpriteColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the attached SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if a SpriteRenderer component is attached
        if (spriteRenderer != null)
        {
            // Set the sprite color to a random color
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
        else
        {
            Debug.LogError("No SpriteRenderer component found on GameObject.");
        }
    }
}
