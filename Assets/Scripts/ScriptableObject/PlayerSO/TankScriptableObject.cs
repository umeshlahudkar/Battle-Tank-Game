
using UnityEngine;


[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public float bulletLaunchForce;
    public float health;
    public float movementSpeed;
    public float rotationSpeed;
    public Color tankColor;
    public BulletType bulletType;
    public TankView tankView;
    public ParticleSystem tankExplosionParticle;
}


