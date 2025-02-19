
using Player.StateMachine.States.Base;
using Player.Systems.JumpSystem;
using Player.Systems.Mono;
using Player.View;

namespace Player.StateMachine.States
{
    public class WallJumpState: BaseJumpState
    {
        private IWallChecker _wallChecker;

        public WallJumpState(Player player) : base(player)
        {
            _wallChecker = player.WallChecker;
            StateType = BehaviourStates.Jump;
        }

        public override void Enter()
        {
            _jumpSystem.Jump(_jumpForce, _wallChecker.WallNormal);
        }

        public override void Update()
        {

        }

        public override void Exit()
        {

        }
    }
}
