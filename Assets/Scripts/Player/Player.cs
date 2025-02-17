using Player.View;
using Player.View.Rigging;
using Player.Systems.JumpSystem;
using Player.Systems.Movement;
using Setup.Player;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [Header("Systems")]
        [field: SerializeField] public JumpSystem JumpSystem { get; private set; }
        [field: SerializeField] public MovementSystem MovementSystem { get; private set; }

        [Header("View")]
        [field: SerializeField, Space] public PlayerView PlayerView { get; private set; }
        [field: SerializeField] public PlayerRiggingController PlayerRiggingController { get; private set; }

        [Header("Configuration")]
        [field: SerializeField, Space] public PlayerSetup PlayerSetup { get; private set; }

        public BaseInput BaseInput { get; private set; }
        
        

        [Inject]
        private void Initialize(BaseInput baseInput)
        {
            BaseInput = baseInput;
        }
    }
}