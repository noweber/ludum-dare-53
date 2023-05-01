using UnityEngine;

public class RandomStartPosition : MonoBehaviour
{
    [SerializeField] private float rangeX = 5f;
    [SerializeField] private float rangeY = 5f;

    private void Awake()
    {
        var currentPosition = transform.position;
        transform.position = new Vector2(
            Random.Range(currentPosition.x - rangeX, currentPosition.x + rangeX),
            Random.Range(currentPosition.y - rangeY, currentPosition.y + rangeY)
        );
    }

    private void OnValidate()
    {
        if (rangeX < 0)
        {
            rangeX = 0;
        }
        if (rangeY < 0)
        {
            rangeY = 0;
        }
    }
}
