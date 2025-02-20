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
            Vector3 normalizedNormal = _wallChecker.WallNormal;
            Vector3 projection = Vector3.ProjectOnPlane(direction, normalizedNormal);
            var newVelocity = new Vector3(projection.x * speed , _rigidbody.linearVelocity.y * .9f, projection.z * speed);

            _rigidbody.linearVelocity = newVelocity;
        }

        public override void Stop()
        {
            var newVelocity = new Vector3(0, _rigidbody.linearVelocity.y, 0);

            _rigidbody.linearVelocity = newVelocity;
        }
    }
}
