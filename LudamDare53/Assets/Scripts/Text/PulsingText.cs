using UnityEngine;
using TMPro;

public class PulsingText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private bool isPulsing = false;

    public float pulseSpeed = 1.5f;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;

    void Start()
    {
        // Get the TextMeshProUGUI component on this game object
        textMesh = GetComponent<TextMeshProUGUI>();
        StartPulsing();
    }

    void Update()
    {
        if (isPulsing)
        {
            // Calculate the alpha value for the text based on a sine wave
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.Sin(Time.time * pulseSpeed));

            // Set the alpha value for the text
            Color color = textMesh.color;
            color.a = alpha;
            textMesh.color = color;
        }
    }

    public void StartPulsing()
    {
        // Start pulsing the text
        isPulsing = true;
    }

    public void StopPulsing()
    {
        // Stop pulsing the text
        isPulsing = false;

        // Reset the alpha value to 1
        Color color = textMesh.color;
        color.a = 1f;
        textMesh.color = color;
    }
}
