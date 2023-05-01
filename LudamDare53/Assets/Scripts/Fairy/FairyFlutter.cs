using UnityEngine;

public class FairyFlutter : MonoBehaviour
{
    public float minSpeed = 1f; // The minimum speed at which the fairy flutters up and down
    public float maxSpeed = 3f; // The maximum speed at which the fairy flutters up and down
    public float minHeight = 0.2f; // The minimum height of the fairy's flutter
    public float maxHeight = 0.8f; // The maximum height of the fairy's flutter

    private Vector3 startingPosition;
    private float speed;
    private float height;

    private void Start()
    {
        startingPosition = transform.position;
        speed = Random.Range(minSpeed, maxSpeed);
        height = Random.Range(minHeight, maxHeight);
    }

    private void FixedUpdate()
    {
        // Calculate the new position based on a sinusoidal wave
        float newY = startingPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
