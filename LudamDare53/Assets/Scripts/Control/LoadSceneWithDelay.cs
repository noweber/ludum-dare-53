using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LoadSceneWithDelay : MonoBehaviour
{
    [SerializeField] private float delaySeconds = 2.0f;
    [SerializeField] private int sceneBuildIndex;
    [SerializeField] private GameObject objectToActivate;

    private float timer = 0.0f;
    private bool canLoadScene = false;

    void Update()
    {
        if (canLoadScene)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(sceneBuildIndex);
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > delaySeconds)
            {
                canLoadScene = true;

                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true);
                }
            }
        }
    }
}
