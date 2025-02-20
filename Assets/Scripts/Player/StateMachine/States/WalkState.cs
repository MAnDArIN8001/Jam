using Player.StateMachine.States.Base;
using Player.Systems.Movement;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class WalkState : BaseMoveState
    {
        public WalkState(Player player) : base(player)
        {
            _movementSpeed = player.PlayerSetup.MovementSpeed;

            StateType = BehaviourStates.Walk;
        }

        public override void Enter() { }

        public override void Exit()
        {
            _movementSystem.Stop();
        }

        protected override void ViewDataUpdate(){}
    }
}