using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPool : GenericMonoSingleton<ParticleSystemPool>
{
    public class ParticleEffect
    {
        public ParticleSystem particleSystem;
        public ParticleSystemType particleType;
        public bool IsUsed;
    }

    public List<ParticleEffect> particles = new List<ParticleEffect>();

    public ParticleSystem GetParticleSystem(ParticleSystem particleSystem, ParticleSystemType particleType)
    {
        if(particles.Count > 0)
        {
            for(int i = 0; i < particles.Count; i++)
            {
                if(particles[i].particleType == particleType && particles[i].IsUsed == false)
                {
                    particles[i].IsUsed = true;
                    return particles[i].particleSystem;
                }
            }
        }
        return CreateNewParticle(particleSystem, particleType);
    }

    public ParticleSystem CreateNewParticle(ParticleSystem particleSystem, ParticleSystemType particleType)
    {
        ParticleEffect newParticle = new ParticleEffect();
        newParticle.particleSystem =Instantiate<ParticleSystem>(particleSystem);
        newParticle.particleType = particleType;
        newParticle.IsUsed = true;
        particles.Add(newParticle);
        return newParticle.particleSystem;
    }

    public void ReturnToPool(ParticleSystem _particlSystem)
    {
        ParticleEffect particlSystem = particles.Find(item => item.particleSystem.Equals(_particlSystem));
        if(particlSystem != null)
        {
            particlSystem.IsUsed = false;
        }
    }
}

public enum ParticleSystemType
{
    None,
    bulletExplosion,
    tankExplosion
}
