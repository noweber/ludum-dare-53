using UnityEngine;

public class RandomizeParticleColors : MonoBehaviour
{
    [SerializeField] private float colorChangeInterval = 0f;
    private ParticleSystem particleSystem;
    private float lastColorChangeTime;

    private void Start()
    {
        // Get the attached particle system
        particleSystem = GetComponent<ParticleSystem>();
        // Record the time of the last color change as the start time
        lastColorChangeTime = Time.time;
    }

    private void Update()
    {
        // Check if enough time has passed since the last color change
        if (Time.time - lastColorChangeTime >= colorChangeInterval)
        {
            // Update the time of the last color change
            lastColorChangeTime = Time.time;
            // Check if color change is enabled
            if (colorChangeInterval > 0)
            {
                // Randomize the particle system's start color
                var main = particleSystem.main;
                main.startColor = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
