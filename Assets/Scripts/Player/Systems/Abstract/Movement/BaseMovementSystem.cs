using UnityEngine;

namespace Player.Systems.Movement
{
    public class BaseMovementSystem : MovementSystem
    {
        private Rigidbody _rigidbody;
        
        public BaseMovementSystem(GameObject context) : base(context)
        {
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