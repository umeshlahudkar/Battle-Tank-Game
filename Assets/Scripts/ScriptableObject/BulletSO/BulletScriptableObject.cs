using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Bullet")]
public class BulletScriptableObject : ScriptableObject
{
    public Color bulletColor;
    public BulletType bulletType;
    public BulletView bulletView;
    public float bulletDamage;
    public ParticleSystem bulletExplosionParticle;
}
