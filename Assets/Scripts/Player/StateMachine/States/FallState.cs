using Player.Systems.Mono;
using Player.Systems.Movement;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class FallState : State
    {
        private float _movementSpeed;

        private Vector2 _lastInput;
        
        private IGroundChecker _groundChecker;

        private MovementSystem _movementSystem;
        
        public FallState(Player player) : base(player)
        {
            _movementSpeed = player.PlayerSetup.MovementSpeed;
            _movementSystem = player.MovementSystem;
            
            StateType = BehaviourStates.Fall;
        }

        public override void Enter()
        {

        }

        public override void Update()
        {
            var input = ReadInputValues();

            if (input != _lastInput)
            {
                
            }

            var movementDirection = _player.transform.forward * input.y + _player.transform.right * input.x;

            _movementSystem.Move(movementDirection, _movementSpeed);
        }

        public override void Exit()
        {

        }

        private Vector2 ReadInputValues() => _player.BaseInput.Controls.Movement.ReadValue<Vector2>();
    }
}