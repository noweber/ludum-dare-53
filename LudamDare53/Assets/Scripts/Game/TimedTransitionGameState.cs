using Assets.Script.Game;
using System.Collections;
using UnityEngine;

namespace Assets.Script.Districts
{
    public sealed class TimedTransitionGameState : BaseGameState, IGameState
    {
        [SerializeField] private float secondsUntilStateTransition = 1f;

        [SerializeField] private GameState StateToTransitionTo = GameState.Start;

        private bool isCoroutineRunning = false;

        private void LateUpdate()
        {
            if (gameObject.activeSelf)
            {
                if (!isCoroutineRunning)
                {
                    StartCoroutine(WaitToStart());
                }
            }
        }

        private IEnumerator WaitToStart()
        {
            isCoroutineRunning = true;
            yield return new WaitForSeconds(secondsUntilStateTransition);
            isCoroutineRunning = false;
            DependencyService.Instance.GameStateMachine().ChangeState(StateToTransitionTo);
        }
    }
}
