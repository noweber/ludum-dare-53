using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float minAngle = -180f;
    public float maxAngle = 180f;
    public bool clockwise = true;

    private Vector3 axis;
    private Quaternion startingRotation;
    private float currentAngle;
    private float direction;

    private void Start()
    {
        // Determine the rotation axis based on the starting direction
        axis = Vector3.forward;
        if (clockwise)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
            axis = -axis;
        }

        // Store the starting rotation of the game object
        startingRotation = transform.rotation;
    }

    private void Update()
    {
        // Calculate the rotation angle based on the elapsed time and the rotation speed
        float angle = rotationSpeed * Time.deltaTime * direction;

        // Rotate the game object around its own pivot point using the specified axis
        transform.Rotate(axis, angle, Space.Self);

        // Calculate the current angle relative to the starting angle
        currentAngle = Quaternion.Angle(startingRotation, transform.rotation);

        // Change direction when reaching the maximum or minimum angle
        if (currentAngle >= maxAngle)
        {
            direction = -1f;
            axis = -axis;
        }
        else if (currentAngle <= minAngle)
        {
            direction = 1f;
            axis = -axis;
        }
    }
}
