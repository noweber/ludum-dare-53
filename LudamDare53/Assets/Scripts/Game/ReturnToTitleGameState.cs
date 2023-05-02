using Assets.Script.Game;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Script.Districts
{
    public class ReturnToTitleGameState : BaseGameState, IGameState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            SceneManager.LoadScene(0);
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
