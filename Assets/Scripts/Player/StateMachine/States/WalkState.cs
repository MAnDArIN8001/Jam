using Player.Systems.Movement;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class WalkState : State
    {
        private float _movementSpeed;
        
        private Vector2 _lastInput;
        
        private MovementSystem _movementSystem;

        private readonly BaseInput _baseInput;
        
        public WalkState(Player player) : base(player)
        {
            _movementSystem = player.MovementSystem;
            _baseInput = player.BaseInput;
            _movementSpeed = player.PlayerSetup.MovementSpeed;

            StateType = BehaviourStates.Walk;
        }

        public override void Enter() { }

        public override void Update()
        {
            var input = ReadInputValues();

            if (input != _lastInput)
            {
                //update view data
            }

            var movementDirection = _player.transform.forward * input.y + _player.transform.right * input.x;

            _movementSystem.Move(movementDirection, _movementSpeed);
        }

        public override void Exit() { }

        private Vector2 ReadInputValues() => _baseInput.Controls.Movement.ReadValue<Vector2>();
    }
}