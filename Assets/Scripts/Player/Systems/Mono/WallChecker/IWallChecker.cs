using System;
using UnityEngine;

namespace Player.Systems.Mono
{
    public interface IWallChecker
    {
        public Vector3 WallNormal { get; }

        public bool IsOnWall { get; }
    }
}
