﻿namespace Platformer.Mechanics.ImpulseCreators
{
    public class ImpulseAmplifiedCollider : ImpulseCreatorCollider
    {
        public float velocityScale;

        protected override void SetImpulseCreator()
        {
            impulseCreator = new ImpulseAmplifier(velocityScale);
        }
    }
}

