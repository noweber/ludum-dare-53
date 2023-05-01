using UnityEngine;

public class RandomSpriteSize : MonoBehaviour
{
    public float minSize = 0.5f; // Minimum size for the sprite
    public float maxSize = 2.0f; // Maximum size for the sprite

    private SpriteRenderer spriteRenderer; // Reference to the Sprite Renderer component

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the Sprite Renderer component attached to the game object
        if (spriteRenderer == null) // Check if there is no Sprite Renderer component
        {
            Debug.LogError("RandomSpriteSize script requires a Sprite Renderer component.");
            return;
        }

        // Generate a random size for the sprite
        float randomSize = Random.Range(minSize, maxSize);

        // Set the new size for the sprite
        spriteRenderer.transform.localScale = new Vector3(randomSize, randomSize, 1.0f);
    }
}
