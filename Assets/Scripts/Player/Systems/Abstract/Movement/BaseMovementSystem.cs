using UnityEngine;

namespace Player.Systems.Movement
{
    public class BaseMovementSystem : MovementSystem
    {
        protected Rigidbody rigidbody;
        
        public BaseMovementSystem(GameObject context) : base(context)
        {
            if (!context.TryGetComponent<Rigidbody>(out rigidbody))
            {
                Debug.LogWarning($"Can't resolve required rigidbody component from {context}");
            }
        }
        
        public override void Move(Vector3 direction, float speed)
        {
            var newVelocity = new Vector3(direction.x * speed, rigidbody.linearVelocity.y, direction.z * speed);

            rigidbody.linearVelocity = newVelocity;
        }
    }
}