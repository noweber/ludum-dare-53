using UnityEngine;

public class RandomYSize : MonoBehaviour
{
    public float minYSize = 1f; // minimum y-axis size
    public float maxYSize = 5f; // maximum y-axis size

    // Start is called before the first frame update
    void Start()
    {
        // get the current scale of the game object
        Vector3 scale = transform.localScale;

        // generate a random size for the y-axis
        float ySize = Random.Range(minYSize, maxYSize);

        // set the new y-axis size in the scale vector
        scale.y = ySize;

        // assign the new scale to the game object
        transform.localScale = scale;
    }
}
