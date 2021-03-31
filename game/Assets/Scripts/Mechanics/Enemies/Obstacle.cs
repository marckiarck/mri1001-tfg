﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Player;

namespace Platformer.Enemies
{
    public class Obstacle : MonoBehaviour
    {
        private Collider2D obstacleCollider;

        private void Awake()
        {
            obstacleCollider = GetComponent<Collider2D>();
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
    }
}

