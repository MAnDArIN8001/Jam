using System;
using System.Collections.Generic;
using Player.StateMachine.States;
using Player.StateMachine.StateTransitions;
using Player.Systems.Mono;
using UnityEngine;

namespace Player.StateMachine.Initializer
{
    public class PlayerStateMachineInitializer : IStateMachineInitializer
    {
        private Player _player;

        public PlayerStateMachineInitializer(Player player)
        {
            _player = player;
        }
        
        public StateMachine InitializeStateMachine()
        {
            var states = new Dictionary<BehaviourStates, State>()
            {
                {BehaviourStates.Idle, new IdleState(_player)},
                {BehaviourStates.Walk, new WalkState(_player)},
                {BehaviourStates.Run, new RunState(_player)},
                {BehaviourStates.Jump, new JumpState(_player)},
                {BehaviourStates.Fall, new FallState(_player)},
                {BehaviourStates.WallRun, new WallRunState(_player)},
                {BehaviourStates.WallJump, new WallJumpState(_player)}
            };

            var transitions = new List<Transition>()
            {
                //IDLE
                
                new Transition(BehaviourStates.Idle, BehaviourStates.Walk, 
                    () => _player.BaseInput.Controls.Movement.ReadValue<Vector2>().magnitude > 0),
                new Transition(BehaviourStates.Idle, BehaviourStates.Jump, 
                    () => _player.BaseInput.Controls.Jump.WasPerformedThisFrame() && _player.GroundingChecker.IsOnGround),

                //Нужно удалить после исправления мгновенного переключения с прыжка на IDLE 
                new Transition(BehaviourStates.Idle, BehaviourStates.WallRun, 
                    () =>  !_player.GroundingChecker.IsOnGround && _player.WallChecker.IsOnWall),
                
                //WALK
               
                new Transition(BehaviourStates.Walk, BehaviourStates.Idle, 
                    () => _player.BaseInput.Controls.Movement.ReadValue<Vector2>().magnitude == 0),
                new Transition(BehaviourStates.Walk, BehaviourStates.Run, 
                    () => _player.BaseInput.Controls.Run.WasPerformedThisFrame() && _player.BaseInput.Controls.Movement.ReadValue<Vector2>().magnitude > 0),
                new Transition(BehaviourStates.Walk, BehaviourStates.Jump, 
                    () => _player.BaseInput.Controls.Jump.WasPerformedThisFrame() && _player.GroundingChecker.IsOnGround),

                //RUN
                
                new Transition(BehaviourStates.Run, BehaviourStates.Walk, 
                    () => _player.BaseInput.Controls.Movement.ReadValue<Vector2>().magnitude > 0),
                new Transition(BehaviourStates.Run, BehaviourStates.Jump, 
                    () => _player.BaseInput.Controls.Jump.WasPerformedThisFrame()),

                //WallRun

                new Transition(BehaviourStates.WallRun, BehaviourStates.Idle,
                    () => !_player.WallChecker.IsOnWall || _player.GroundingChecker.IsOnGround),
                new Transition(BehaviourStates.WallRun, BehaviourStates.WallJump,
                    () => _player.BaseInput.Controls.Jump.WasPerformedThisFrame() && _player.WallChecker.IsOnWall),

                
                //WallJump

                new Transition(BehaviourStates.WallJump, BehaviourStates.Idle,
                    () => _player.GroundingChecker.IsOnGround),

                //JUMP

                new Transition(BehaviourStates.Jump, BehaviourStates.Idle, 
                    () => _player.GroundingChecker.IsOnGround),
                new Transition(BehaviourStates.Jump, BehaviourStates.WallRun,
                    () => !_player.GroundingChecker.IsOnGround && _player.WallChecker.IsOnWall),
                
                //FALL
                
                new Transition(BehaviourStates.Fall, BehaviourStates.Idle,
                    () => _player.GroundingChecker.IsOnGround && _player.BaseInput.Controls.Movement.ReadValue<Vector2>().magnitude == 0),
            };

            return new StateMachine(states, transitions);
        }
    }
}