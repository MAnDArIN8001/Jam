using Player.Systems.Mono;
using Player.Systems.Movement;
using UnityEngine;

namespace Player.Systems
{
    public class WallMovementSystem : MovementSystem
    {
        private readonly IWallChecker _wallChecker;

        private readonly Rigidbody _rigidbody;

        public WallMovementSystem(GameObject context, IWallChecker wallChecker) : base(context)
        {
            _wallChecker = wallChecker;

            if (!context.TryGetComponent<Rigidbody>(out _rigidbody))
            {
                Debug.LogWarning($"Can't resolve required rigidbody component from {context}");
            }
        }

        public override void Move(Vector3 direction, float speed)
        {
            var newVelocity = new Vector3(direction.x * speed, _rigidbody.linearVelocity.y, direction.z * speed);

            _rigidbody.linearVelocity = newVelocity;
        }

        public override void Stop()
        {
            var newVelocity = new Vector3(0, _rigidbody.linearVelocity.y, 0);

            _rigidbody.linearVelocity = newVelocity;
        }
    }
}
