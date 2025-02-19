using Player.StateMachine.Initializer;
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

        [field: SerializeField, Header("View")] public PlayerView PlayerView { get; private set; }
        [field: SerializeField] public PlayerRiggingController PlayerRiggingController { get; private set; }
        
        [field: SerializeField, Space, Header("Configuration")] public PlayerSetup PlayerSetup { get; private set; }

        [field: SerializeField, Space, Header("Controls components")] public GroundingChecker GroundingChecker { get; private set; }

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

            var playerFSMInitializer = new PlayerStateMachineInitializer(this);
            
            _stateMachine = playerFSMInitializer.InitializeStateMachine();
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