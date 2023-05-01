using UnityEngine;

public class RandomGreenColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = GetRandomGreenColor();
        }
    }

    private Color GetRandomGreenColor()
    {
        float hue = Random.Range(0.2f, 0.4f); // limit the hue to green colors
        float saturation = Random.Range(0.5f, 1f);
        float value = Random.Range(0.5f, 1f);
        return Color.HSVToRGB(hue, saturation, value);
    }
}
