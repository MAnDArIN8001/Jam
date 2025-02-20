using UnityEngine;

namespace Player.Systems.Mono
{
    public class GroundingChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] private float _checkDistance;

        [Space, SerializeField] private Transform _checkerPoint;

        public bool IsOnGround => _isOnGround;

       // private bool CheckForGround() => Physics.Raycast(_checkerPoint.position, -transform.up, _checkDistance);

        [SerializeField, Range(0, 1)] private float _tolerance = 0.9f;
        private bool _isOnGround;

        private void OnCollisionEnter(Collision collision)
        {
            CheckWallCollision(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            CheckWallCollision(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            CheckWallCollision(collision);
        }

        private bool IsVectorUpward(Vector3 vector)
        {
            float dot = Vector3.Dot(vector.normalized, Vector3.up);

            return dot >= _tolerance;
        }

        private void CheckWallCollision(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (!IsVectorUpward(contact.normal)) continue;

                _isOnGround = true;
                return;
            }

            _isOnGround = false;
        }
    }
}