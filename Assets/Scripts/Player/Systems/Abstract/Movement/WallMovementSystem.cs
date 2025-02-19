using Player.Systems.Mono;
using Player.Systems.Movement;
using UnityEngine;

namespace Player.Systems
{
    public class WallMovementSystem : BaseMovementSystem
    {
        private readonly IWallChecker _wallChecker;

        public WallMovementSystem(GameObject context, IWallChecker wallChecker) : base(context)
        {
            _wallChecker = wallChecker;
        }

        public override void Move(Vector3 direction, float speed)
        {
            base.Move(direction, speed);
            rigidbody.AddForce(-_wallChecker.WallNormal);
        }

    }
}
