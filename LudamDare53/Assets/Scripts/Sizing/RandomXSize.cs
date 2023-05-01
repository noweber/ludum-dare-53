using UnityEngine;

public class RandomXSize : MonoBehaviour
{
    public float minSize = 1f; // minimum x-axis size
    public float maxSize = 5f; // maximum x-axis size

    // Start is called before the first frame update
    void Start()
    {
        // get the current scale of the game object
        Vector3 scale = transform.localScale;

        // generate a random size for the x-axis
        float xSize = Random.Range(minSize, maxSize);

        // set the new x-axis size in the scale vector
        scale.x = xSize;

        // assign the new scale to the game object
        transform.localScale = scale;
    }
}
