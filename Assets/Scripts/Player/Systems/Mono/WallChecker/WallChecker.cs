using System;
using Player.StateMachine.StateTransitions;
using UnityEngine;

namespace Player.Systems.Mono
{
    public class WallChecker : MonoBehaviour, IWallChecker
    {
        public bool IsOnWall => _isOnWall;

        public Vector3 WallNormal => _wallNormal;

        [SerializeField] private Transform _checkPoint;
        
        private Vector3 _wallNormal;
        
        private bool _isOnWall;

        [SerializeField] private float _checkDistance = 1.0f;

        private void Update()
        {
            CheckForWalls();
        }

        private void CheckForWalls()
        {
            _isOnWall = CheckWall(-_checkPoint.right);
            _isOnWall |= CheckWall(_checkPoint.right);
        }

        private bool CheckWall(Vector3 direction)
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _checkDistance))
            {
                _wallNormal = hit.normal;
                
                Debug.DrawLine(transform.position, hit.point, Color.red);
                
                return true;
            }
            
            Debug.DrawLine(transform.position, transform.position + direction.normalized * _checkDistance, Color.green);

            return false;
        }
    }
}
