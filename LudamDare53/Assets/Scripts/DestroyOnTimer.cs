using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    public float SecondsUntilDestruction = 4f;

    void Start()
    {
        Destroy(transform.gameObject, SecondsUntilDestruction);
    }
}
