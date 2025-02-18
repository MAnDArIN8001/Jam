using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.StateMachine.States
{
    public class IdleState : State
    {
        private readonly BaseInput _baseInput;

        private StateMachine _stateMachine;
        
        public IdleState(Player player) : base(player)
        {
            _baseInput = player.BaseInput;
            _stateMachine = player.StateMachine;
        }
        
        public override void Enter() { }

        public override void Update() { }

        public override void Exit() { }
    }
}