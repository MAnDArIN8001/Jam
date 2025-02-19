using Player.Systems.Mono;
using UnityEngine;

namespace Player.Systems.JumpSystem
{
    public class WallJumpSystem : BaseJumpSystem
    {
        private readonly IWallChecker wallChecker;

        public WallJumpSystem(
            GameObject context, 
            IGroundChecker groundChecker, 
            IWallChecker wallChecker, 
            float jumpForce) : 
            base(context, groundChecker, jumpForce)
        {
            this.wallChecker = wallChecker;
        }
        public override void Jump()
        {
            if (!wallChecker.IsOnWall) return;

            base.Jump(wallChecker.WallNormal);
        }
    }
}
