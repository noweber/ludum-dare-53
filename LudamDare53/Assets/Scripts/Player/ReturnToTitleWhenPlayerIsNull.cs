using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public sealed class ReturnToTitleWhenPlayerIsNull : MonoBehaviour
    {
        [SerializeField] private PlayerController player;

        private void Start()
        {
            player = GameObject.FindObjectOfType<PlayerController>();
        }

        private void FixedUpdate()
        {
            if (player == null)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
