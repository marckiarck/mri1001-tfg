﻿using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.TimeModifiers;
using UnityEngine;

namespace Platformer.Mechanics.Enemies
{
    /// <summary>
    /// Obstacle static in a location that kills PlayerController when collides with him
    /// </summary>
    public class Obstacle : TimeAffectedObject
    {
        private Collider2D obstacleCollider;

        private void Awake()
        {
            obstacleCollider = GetComponent<Collider2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                PlayerObstacleCollision ev = Simulation.Schedule<PlayerObstacleCollision>();
                ev.player = player;
            }
        }

        protected override void Move()
        {

        }
    }
}

