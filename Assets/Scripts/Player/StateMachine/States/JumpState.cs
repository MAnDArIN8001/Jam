using Player.StateMachine.States.Base;
using Player.Systems.JumpSystem;
using Player.View;

namespace Player.StateMachine.States
{
    public class JumpState : BaseJumpState
    {

        public JumpState(Player player) : base(player)
        {          
            StateType = BehaviourStates.Jump;
        }

        public override void Enter()
        {
            _jumpSystem.Jump(_jumpForce);
        }

        public override void Update() { }

        public override void Exit() { }
    }
}