using Player.Systems.Mono;
using UnityEngine;

namespace Player.Systems.JumpSystem
{
    public class BaseJumpSystem : JumpSystem
    {
        private bool _onGround;
        
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

            groundChecker.OnGrounded += HandleGrounding;
        }
        
        public override void Jump()
        {
            if (!_onGround)
            {
                return;
            }

            _onGround = false;
            
            var newVelocity = (_context.transform.up * _jumpForce) + _rigidbody.linearVelocity;

            _rigidbody.linearVelocity = newVelocity;
        }

        public override void Dispose()
        {
            if (_groundChecker is not null)
            {
                _groundChecker.OnGrounded -= HandleGrounding;
            }
        }

        private void HandleGrounding()
        {
            _onGround = true;
        }
    }
}