using Player.Systems.Mono;
using Player.Systems.Movement;
using UnityEngine;

namespace Player.Systems
{
    public class BaseWallMovementSystem : BaseMovementSystem
    {
        private readonly IWallChecker _wallChecker;

        public BaseWallMovementSystem(GameObject context, IWallChecker wallChecker) : base(context)
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
