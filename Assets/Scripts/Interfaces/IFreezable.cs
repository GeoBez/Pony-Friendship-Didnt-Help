using UnityEngine;

interface IFreezable
{
    void FreezingAnimationStart();
    void FreezingStart(Ice ice);
    void FreezingEnd(ParticleSystem iceDestroyParticle);
}