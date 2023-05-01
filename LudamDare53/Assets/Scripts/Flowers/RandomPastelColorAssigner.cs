using UnityEngine;

public class RandomPastelColorAssigner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToColor;

    private Color pastelColor;

    private void Start()
    {
        pastelColor = GetRandomPastelColor();
        AssignRandomColorToObjects();
    }

    private Color GetRandomPastelColor()
    {
        float hue = Random.Range(0f, 1f);
        float saturation = Random.Range(0.2f, 0.8f);
        float value = Random.Range(0.7f, 0.9f);
        return Color.HSVToRGB(hue, saturation, value);
    }

    private void AssignRandomColorToObjects()
    {
        foreach (GameObject obj in objectsToColor)
        {
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = pastelColor;
            }
            else
            {
                Debug.LogWarning($"Could not find SpriteRenderer component on {obj.name}.");
            }
        }
    }
}
