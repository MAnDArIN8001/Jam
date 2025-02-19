using System;

namespace Player.Systems.Mono
{
    public interface IGroundChecker
    {
        public bool IsOnGround { get; }
    }
}