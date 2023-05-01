using UnityEngine;

public class RandomCameraBackgroundColors : MonoBehaviour
{
    public float transitionDuration = 2f; // the time it takes to transition to a new color
    public float colorChangeInterval = 5f; // the time between color changes
    private Camera attachedCamera; // the camera component
    private Color targetColor; // the color to transition to
    private float transitionTimer; // the timer for the color transition

    void Start()
    {
        attachedCamera = GetComponent<Camera>(); // get the camera component
        targetColor = Random.ColorHSV(); // select a random color to transition to
        attachedCamera.backgroundColor = targetColor; // set the initial color of the camera's background
        transitionTimer = transitionDuration; // set the timer to the duration of the transition
    }

    void Update()
    {
        transitionTimer += Time.deltaTime; // increment the timer by the amount of time that has passed since the last frame
        if (transitionTimer >= transitionDuration) // if the timer has reached the duration of the transition
        {
            targetColor = Random.ColorHSV(); // select a new random color to transition to
            transitionTimer = 0f; // reset the timer to 0
        }

        attachedCamera.backgroundColor = Color.Lerp(attachedCamera.backgroundColor, targetColor, Time.deltaTime / transitionDuration); // smoothly transition to the target color over time
    }
}
