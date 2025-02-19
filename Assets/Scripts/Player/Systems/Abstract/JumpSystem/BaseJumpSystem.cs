using Player.Systems.Mono;
using UnityEngine;

namespace Player.Systems.JumpSystem
{
    public class BaseJumpSystem : JumpSystem
    {
        private float _jumpForce;

        private IGroundChecker _groundChecker;
        
        private readonly Rigidbody _rigidbody;
        
        public BaseJumpSystem(GameObject context, IGroundChecker groundChecker, float jumpForce) : base(context)
        {
            _jumpForce = jumpForce;
            _groundChecker = groundChecker;
            
            if (!context.TryGetComponent<Rigidbody>(out _rigidbody))
            {
                Debug.LogWarning($"Can't resolve required rigidbody component from {context}");
            }
        }
        
        public override void Jump()
        {
            if (!_groundChecker.IsOnGround) return;

            this.Jump(_context.transform.up);
        }

        protected override void Jump(Vector3 direction)
        {
            var newVelocity = (direction * _jumpForce) + _rigidbody.linearVelocity;

            _rigidbody.linearVelocity = newVelocity;
        }
    }
}