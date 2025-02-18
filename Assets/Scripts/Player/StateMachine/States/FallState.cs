using Player.Systems.Mono;

namespace Player.StateMachine.States
{
    public class FallState : State
    {
        private IGroundChecker _groundChecker;
        
        public FallState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}