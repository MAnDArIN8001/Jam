using Player.Systems.JumpSystem;
using Player.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.StateMachine.States.Base
{
    public abstract class BaseJumpState : State
    {
        protected float _jumpForce;
        protected JumpSystem _jumpSystem;
        protected PlayerView _playerView;

        public BaseJumpState(Player player) : base(player)
        {
            _jumpForce = player.PlayerSetup.JumpForce;
            _jumpSystem = player.JumpSystem;
            _playerView = player.PlayerView;
        }
    }
}
