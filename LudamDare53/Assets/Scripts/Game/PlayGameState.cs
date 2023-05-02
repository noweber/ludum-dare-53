using Assets.Script.Game;

namespace Assets.Script.Districts
{
    public class PlayGameState : BaseGameState, IGameState
    {

        private void FixedUpdate()
        {
            if (gameObject.activeSelf && DependencyService.Instance.PlayerController() == null)
            {
                DependencyService.Instance.GameStateMachine().ChangeState(GameState.Lose);
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
