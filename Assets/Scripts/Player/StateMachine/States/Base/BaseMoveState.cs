using Player.Systems.Movement;
using System;
using UnityEditor;
using UnityEngine;

namespace Player.StateMachine.States.Base
{
    public abstract class BaseMoveState: State
    {
        protected float _movementSpeed;

        protected Vector2 _lastInput;

        protected MovementSystem _movementSystem;

        protected readonly BaseInput _baseInput;

        public BaseMoveState(Player player) : base(player)
        {
            _movementSystem = player.MovementSystem;
            _baseInput = player.BaseInput;
        }


        public override void Update()
        {
            var input = ReadInputValues();

            if (input != _lastInput)
            {
                //update view data
                ViewDataUpdate();
            }

            var movementDirection = _player.transform.forward * input.y + _player.transform.right * input.x;

            _movementSystem.Move(movementDirection, _movementSpeed);
        }

        protected abstract void ViewDataUpdate();
        
        protected Vector2 ReadInputValues() => _baseInput.Controls.Movement.ReadValue<Vector2>();

    }
}
