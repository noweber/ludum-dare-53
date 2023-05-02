using Assets.Script.Game;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Script
{
    public class DependencyService : Singleton<DependencyService>
    {
        [SerializeField]
        private GameStateMachine gameStateMachine;

        [SerializeField]
        private PlayerController playerController;

        public GameStateMachine GameStateMachine()
        {
            if (gameStateMachine == null)
            {
                gameStateMachine = FindObjectOfType<GameStateMachine>();
            }
            return gameStateMachine;
        }

        public PlayerController PlayerController()
        {
            if (playerController == null)
            {
                playerController = FindObjectOfType<PlayerController>();
            }
            return playerController;
        }
    }
}
