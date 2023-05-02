using Assets.Script.Districts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Game
{
    public enum GameState
    {
        Start,
        Tutorial,
        Play,
        LevelUp,
        Menu,
        Lose,
        ReturnToTitle
    }

    public class GameStateMachine : MonoBehaviour
    {
        public TimedTransitionGameState StartState;

        public TutorialGameState TutorialGameState;

        public PlayGameState PlayGameState;

        public TimedTransitionGameState LoseState;
            
        public ReturnToTitleGameState ReturnToTitleState;

        private Dictionary<GameState, IGameState> gameStates;

        private Dictionary<GameState, GameObject> gameObjects;

        [SerializeField]
        public GameState CurrentState { get; private set; }

        void Awake()
        {
            gameStates = new()
            {
                { GameState.Start, StartState },
                { GameState.Tutorial, TutorialGameState },
                { GameState.Play, PlayGameState },
                { GameState.Lose, LoseState },
                { GameState.ReturnToTitle, ReturnToTitleState },
            };
            gameObjects = new()
            {
                { GameState.Start, StartState.gameObject },
                { GameState.Tutorial, TutorialGameState.gameObject },
                { GameState.Play, PlayGameState.gameObject },
                { GameState.Lose, LoseState.gameObject },
                { GameState.ReturnToTitle, ReturnToTitleState.gameObject },
            };
        }

        private void Start()
        {
            ChangeState(GameState.Start, false);
        }

        public void ChangeState(GameState nextState, bool exitCurrentState = true)
        {
            if (!gameStates.ContainsKey(nextState))
            {
                Debug.LogError("Next state is invalid.");
                return;
            }

            if (exitCurrentState && gameStates.ContainsKey(CurrentState))
            {
                gameStates[CurrentState].OnExit();
                gameObjects[CurrentState].SetActive(false);
            }

            CurrentState = nextState;
            gameObjects[CurrentState].SetActive(true);
            gameStates[CurrentState].OnEnter();
        }
    }
}
