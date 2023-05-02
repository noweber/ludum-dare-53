using Assets.Script;
using Assets.Script.Game;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ChangeGameStateOnce : MonoBehaviour
    {
        [SerializeField] private GameState stateToChangeTo;

        private void LateUpdate()
        {
            if (gameObject.activeSelf)
            {
                DependencyService.Instance.GameStateMachine().ChangeState(stateToChangeTo);
                Destroy(this);
            }
        }
    }
}
