using NUnit.Framework.Constraints;
using UnityEngine;

namespace Player.Systems.Mono
{
    public class WallChecker : MonoBehaviour, IWallChecker
    {
        public bool IsOnWall => _isOnWall;

        public Vector3 WallNormal => _wallNormal;
        
        [SerializeField, Range(0,1)] private float _tolerance = 0.2f;

        private Vector3 _wallNormal;
        [field: SerializeField] private bool _isOnWall;


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

        private void CheckWallCollision(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (Mathf.Abs(contact.normal.y) > _tolerance) continue;

                _wallNormal = contact.normal;
                _isOnWall = true;
                return;
            }

            _wallNormal = Vector3.zero;
            _isOnWall = false;
        }
    }
}
