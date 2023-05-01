using UnityEngine;

public class RandomMeander : MonoBehaviour
{
    public float minSpeed = 1.0f; // Minimum speed of meander
    public float maxSpeed = 5.0f; // Maximum speed of meander
    public float minMagnitude = 1.0f; // Minimum magnitude of meander
    public float maxMagnitude = 5.0f; // Maximum magnitude of meander
    public bool meanderAlongXAxis = true;
    public bool meanderAlongYAxis = false;

    private Vector3 originalPosition; // Original position of object
    [SerializeField] private Vector3 targetPosition; // Target position of object
    private float speed; // Current speed of meander
    private float magnitude; // Current magnitude of meander
    private int direction = 1; // Meander direction: 1 for right, -1 for left

    void Start()
    {
        originalPosition = transform.position; // Save original position of object
        ResetTargetPosition(); // Set initial target position and meander parameters
    }

    void Update()
    {
        // Move object towards target position at current speed and direction
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If object reaches target position, change direction and reset target position and meander parameters
        if (HasObjectReachedTarget())
        {
            direction *= -1; // Change direction
            ResetTargetPosition(); // Set new target position and meander parameters
        }
    }

    bool HasObjectReachedTarget()
    {
        bool xTargetReached = true;
        bool yTargetReached = true;
        if (meanderAlongXAxis)
        {
            xTargetReached = false;
            if (direction >= 0)
            {
                if (transform.position.x >= targetPosition.x)
                {
                    xTargetReached = true;
                }
            }
            else if (direction <= 0)
            {
                if (transform.position.x <= targetPosition.x)
                {
                    xTargetReached = true;
                }
            }
        }
        if (meanderAlongYAxis)
        {
            yTargetReached = false;
            if (direction >= 0)
            {
                if (transform.position.y >= targetPosition.y)
                {
                    yTargetReached = true;
                }
            }
            else if (direction <= 0)
            {
                if (transform.position.y <= targetPosition.y)
                {
                    yTargetReached = true;
                }
            }
        }
        return (xTargetReached && yTargetReached);
    }

    void ResetTargetPosition()
    {
        // Set random magnitude within meander range
        magnitude = Random.Range(minMagnitude, maxMagnitude);

        float xPosition = originalPosition.x;
        float yPosition = originalPosition.y;
        float meanderMagnitude = direction * magnitude;
        if (meanderAlongXAxis)
        {
            xPosition += meanderMagnitude;
        }
        if (meanderAlongYAxis)
        {
            yPosition += meanderMagnitude;
        }

        // Set random target position within meander range and opposite direction of current meander
        targetPosition = new Vector3(xPosition, yPosition, originalPosition.z);

        // Set random speed within meander range
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
