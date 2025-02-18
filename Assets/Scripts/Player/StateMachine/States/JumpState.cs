using Player.Systems.JumpSystem;
using Player.View;

namespace Player.StateMachine.States
{
    public class JumpState : State
    {
        private JumpSystem _jumpSystem;
        
        private PlayerView _playerView;

        public JumpState(Player player) : base(player)
        {
            _jumpSystem = player.JumpSystem;
            _playerView = player.PlayerView;
        }

        public override void Enter()
        {
            _jumpSystem.Jump();
        }

        public override void Update() { }

        public override void Exit() { }
    }
}