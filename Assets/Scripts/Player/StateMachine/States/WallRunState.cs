
using Player.StateMachine.States.Base;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class WallRunState: BaseMoveState
    {
        private readonly BaseInput _baseInput;

        public WallRunState(Player player) : base(player)
        {
            _movementSystem = player.WallMovementSystem;

            StateType = BehaviourStates.WallRun;
        }

        public override void Enter() { }

        public override void Exit() { }

        protected override void ViewDataUpdate() { }
    }
}
