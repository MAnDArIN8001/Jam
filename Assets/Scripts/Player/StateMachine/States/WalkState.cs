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
        }

        public override void Enter() { }

        public override void Update()
        {
            var input = ReadInputValues();

            if (input != _lastInput)
            {
                //update view data
            }

            _movementSystem.Move(_player.transform.forward, _movementSpeed);
        }

        public override void Exit() { }

        private Vector2 ReadInputValues() => _baseInput.Controls.Movement.ReadValue<Vector2>();
    }
}