﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using System;

namespace Platformer.Mechanics.KinematicObjects
{

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class KinematicObject : TimeAfectedObject
    {

        public Rigidbody2D rigidBody;
        public Collider2D mycollider;
        private KinematicObjectCollisionManager collisionManager;
        private KinematicObjectGravityManager gravityManager;

        public bool simulatingPhysics = true;
        private bool grounded = true;


        public bool Grounded { get => grounded;}

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            mycollider = GetComponent<Collider2D>();
            collisionManager = new KinematicObjectCollisionManager(this);
            gravityManager = new KinematicObjectGravityManager(this);
        }

        protected virtual void FixedUpdate()
        {
            if (simulatingPhysics)
            {
                gravityManager.ManageGravity();
                collisionManager.manageCollision();
                if(PhisicsController.GetVelocity(this).y == 0)
                {
                    grounded = true;
                }
                else
                {
                    grounded = false;
                }

                Move();
            }
            else
            {
                PhisicsController.SetVelocity(this, Vector2.zero);
            }
        }

        protected override void Move()
        {
            Vector2 velocity = PhisicsController.GetVelocity(this);
            Vector2 scaledVelocity = velocity * TimeScale;
            PhisicsController.SetVelocity(this, scaledVelocity);
        }

        public override void SetTimeScale(float timeScale)
        {
            base.SetTimeScale(timeScale);
            Move();
        }

        public override void ResetTimeScale()
        {
            Vector2 velocity = PhisicsController.GetVelocity(this);
            Vector2 unScaledVelocity = velocity / TimeScale;
            PhisicsController.SetVelocity(this, unScaledVelocity);
            base.ResetTimeScale();
        }

        public void ApplyGravityAlteration(Vector2 gravityAlteration)
        {
            gravityManager.addGravityAlteration(gravityAlteration);
        }
    }
}
