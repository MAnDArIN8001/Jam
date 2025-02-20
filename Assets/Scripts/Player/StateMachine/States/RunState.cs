using Player.Systems.Movement;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class RunState : State
    {
        private float _runSpeed;

        private Vector2 _lastInput;
        
        private MovementSystem _movementSystem;

        private BaseInput _input;

        public RunState(Player player) : base(player)
        {
            _runSpeed = player.PlayerSetup.RunningSpeed;
            _movementSystem = player.MovementSystem;
            _input = player.BaseInput;
            
            StateType = BehaviourStates.Walk;
        }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            var input = ReadInputValues();

            if (input != _lastInput)
            {
                //update view data
            }

            var movementDirection = _player.transform.forward * input.y + _player.transform.right * input.x;

            _movementSystem.Move(movementDirection, _runSpeed);
        }

        public override void Exit()
        {
            
        }
        
        protected Vector2 ReadInputValues() => _input.Controls.Movement.ReadValue<Vector2>();
    }
}