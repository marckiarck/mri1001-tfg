﻿using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    public class ImpulseParticle : ImpulseCreator
    {
        private Vector2 impulseAplied;

        public ImpulseParticle(Vector2 impulseAplied)
        {
            this.impulseAplied = impulseAplied;
        }

        public void ImpulseKinematicObject(KinematicObject kineObj)
        {
            PhysicsController.ApplyImpulse(kineObj, impulseAplied);
        }
    }
}

