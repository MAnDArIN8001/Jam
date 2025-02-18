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

            _stateMachine = new StateMachine.StateMachine(this);
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