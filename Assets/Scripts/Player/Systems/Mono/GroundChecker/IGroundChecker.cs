using System;

namespace Player.Systems.Mono
{
    public interface IGroundChecker
    {
        public event Action OnGrounded;

        public bool IsOnGround { get; }
    }
}