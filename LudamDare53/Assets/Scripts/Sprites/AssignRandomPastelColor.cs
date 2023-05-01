using UnityEngine;

public class AssignRandomPastelColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Generate a random pastel color
            Color pastelColor = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));

            // Set the sprite renderer's color to the random pastel color
            spriteRenderer.color = pastelColor;
        }
    }
}
