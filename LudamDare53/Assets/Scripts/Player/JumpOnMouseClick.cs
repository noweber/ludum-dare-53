using UnityEngine;

public class JumpOnMouseClick : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // The force applied when the player clicks the mouse
    [SerializeField] private float cooldownTime = 0.125f; // The time in seconds between each jump

    private float lastJumpTime = -Mathf.Infinity; // The time when the player last jumped, initialized to negative infinity

    private void Update()
    {
        // Check if the player clicked the mouse and enough time has passed since the last jump
        if (Input.GetMouseButton(0) && Time.time - lastJumpTime >= cooldownTime)
        {
            // Apply an upward force to the object
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Update the last jump time to the current time
            lastJumpTime = Time.time;
        }
    }
}
