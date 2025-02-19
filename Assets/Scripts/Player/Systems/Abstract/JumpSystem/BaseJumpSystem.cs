using Player.Systems.Mono;
using UnityEngine;

namespace Player.Systems.JumpSystem
{
    public class BaseJumpSystem : JumpSystem
    {
           
        public BaseJumpSystem(GameObject context) : base(context)
        {
        }
        

        public override void Jump(float jumpForce, Vector3 direction = default)
        {
            if(direction == default) direction = _context.transform.up;

            base.Jump(jumpForce, direction);
        }
    }
}