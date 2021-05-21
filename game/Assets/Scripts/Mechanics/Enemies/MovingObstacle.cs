﻿using UnityEngine;

namespace Platformer.Mechanics.Enemies
{
    public class MovingObstacle : Obstacle
    {
        public float speed = 5f;

        protected override void Move()
        {
            Vector3 traveledDistance = (Vector3)Vector2.left * speed * Time.fixedDeltaTime;
            Vector3 timeAfectedTraveledDistance = traveledDistance * TimeScale;
            transform.position += timeAfectedTraveledDistance;
        }
    }
}

