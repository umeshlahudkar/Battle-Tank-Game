using UnityEngine;
public class BulletModel
{
    public BulletController bulletController { get; private set; }
    public Color bulletColor { get; private set; }
    public float bulletSpeed { get; private set; }
    public float bulletDamage { get; private set; }
    public BulletType bulletType { get; private set; }
    public Vector3 currentVelocity { get; set; }
    public ParticleSystem bulletExplosionParticle { get; private set; }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public BulletModel(BulletScriptableObject scriptableObject)
    {
        bulletDamage = scriptableObject.bulletDamage;
        bulletType = scriptableObject.bulletType;
        bulletColor = scriptableObject.bulletColor;
        bulletExplosionParticle = scriptableObject.bulletExplosionParticle;
    }
}
