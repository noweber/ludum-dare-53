using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHitPoints = 100;
    public int minHitPoints = 0;
    public int currentHitPoints = 100;
    public Slider slider;
    public float oscillationSpeed = 2f;
    public float oscillationAmplitude = 25f;

    private void Start()
    {
        slider.maxValue = maxHitPoints;
        slider.minValue = minHitPoints;
        slider.value = currentHitPoints;
    }

    private void Update()
    {
        float oscillation = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmplitude;
        currentHitPoints = Mathf.RoundToInt(maxHitPoints * (oscillation + 50) / 100f);

        slider.value = currentHitPoints;
    }
}
