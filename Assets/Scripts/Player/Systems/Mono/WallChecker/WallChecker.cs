using System;
using UnityEngine;

namespace Player.Systems.Mono
{
    public class WallChecker : MonoBehaviour, IWallChecker
    {
        public bool IsOnWall => _isOnWall;

        public Vector3 WallNormal => _wallNormal;

        private Vector3 _wallNormal;
        private bool _isOnWall;

        [SerializeField] private float checkDistance = 1.0f; // Дистанция проверки

        private void Update()
        {
            CheckForWalls();
        }

        private void CheckForWalls()
        {
            // Проверяем наличие стены слева
            CheckWall(Vector3.left);

            // Проверяем наличие стены справа
            CheckWall(Vector3.right);
        }

        private void CheckWall(Vector3 direction)
        {
            // Выполняем Raycast
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, checkDistance))
            {
                _isOnWall = true;
                _wallNormal = hit.normal;
                return;
                // Вызываем событие, если игрок коснулся стены
            }
            _isOnWall = false;
        }
    }
}
