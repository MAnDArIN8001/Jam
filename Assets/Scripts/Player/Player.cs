using System.Collections.Generic;
using Player.StateMachine;
using Player.StateMachine.States;
using Player.StateMachine.StateTransitions;
using Player.View;
using Player.View.Rigging;
using Player.Systems.JumpSystem;
using Player.Systems.Mono;
using Player.Systems.Movement;
using Setup.Player;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public JumpSystem JumpSystem { get; private set; }
        public MovementSystem MovementSystem { get; private set; }

        [Header("View")]
        [field: SerializeField, Space] public PlayerView PlayerView { get; private set; }
        [field: SerializeField] public PlayerRiggingController PlayerRiggingController { get; private set; }

        [Header("Configuration")]
        [field: SerializeField, Space] public PlayerSetup PlayerSetup { get; private set; }

        [Header("Controls components")] 
        [field: SerializeField, Space] public GroundingChecker GroundingChecker { get; private set; }

        private BaseInput _baseInput;

        private StateMachine.StateMachine _stateMachine;

        public BaseInput BaseInput => _baseInput;

        public StateMachine.StateMachine StateMachine => _stateMachine;

        [Inject]
        private void Initialize(BaseInput baseInput)
        {
            _baseInput = baseInput;

            MovementSystem = new BaseMovementSystem(gameObject);
            JumpSystem = new BaseJumpSystem(gameObject, GroundingChecker, PlayerSetup.JumpForce);
            
            var states = new Dictionary<BehaviourStates, State>()
            {
                {BehaviourStates.Idle, new IdleState(this)},
                {BehaviourStates.Walk, new WalkState(this)},
                {BehaviourStates.Run, new RunState(this)},
                {BehaviourStates.Jump, new JumpState(this)},
                {BehaviourStates.Fall, new FallState(this)}
            };

            var transitions = new List<Transition>()
            {
                new Transition(BehaviourStates.Idle, BehaviourStates.Walk, 
                    () => _baseInput.Controls.Movement.ReadValue<Vector2>().magnitude > 0),
                new Transition(BehaviourStates.Walk, BehaviourStates.Idle, 
                    () => _baseInput.Controls.Movement.ReadValue<Vector2>().magnitude == 0),
                new Transition(BehaviourStates.Idle, BehaviourStates.Jump, 
                    () => _baseInput.Controls.Jump.WasPerformedThisFrame()),
                new Transition(BehaviourStates.Jump, BehaviourStates.Idle, 
                    () => GroundingChecker.IsOnGround),
                new Transition(BehaviourStates.Walk, BehaviourStates.Run, 
                    () => _baseInput.Controls.Run.WasPerformedThisFrame() && _baseInput.Controls.Movement.ReadValue<Vector2>().magnitude > 0),
                new Transition(BehaviourStates.Run, BehaviourStates.Walk, 
                    () => _baseInput.Controls.Movement.ReadValue<Vector2>().magnitude > 0),
                new Transition(BehaviourStates.Walk, BehaviourStates.Jump, 
                    () => _baseInput.Controls.Jump.WasPerformedThisFrame()),
                new Transition(BehaviourStates.Run, BehaviourStates.Jump, 
                    () => _baseInput.Controls.Jump.WasPerformedThisFrame()),
                new Transition(BehaviourStates.Fall, BehaviourStates.Idle,
                    () => GroundingChecker.IsOnGround && _baseInput.Controls.Movement.ReadValue<Vector2>().magnitude == 0),
            };
            
            _stateMachine = new StateMachine.StateMachine(states, transitions);
        }

        public void Update()
        {
            _stateMachine.Update();
        }

        public void OnDestroy()
        {
            _stateMachine.Dispose();
            
            MovementSystem.Dispose();
            JumpSystem.Dispose();
        }
    }
}