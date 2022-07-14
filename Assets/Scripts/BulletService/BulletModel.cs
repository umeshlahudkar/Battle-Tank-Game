
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    private float bulletSpeed;
    private float bulletDamage;
    private BulletType bulletType;

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public BulletModel(BulletScriptableObject scriptableObject)
    {
        bulletSpeed = scriptableObject.speed;
        bulletDamage = scriptableObject.bulletDamage;
        bulletType = scriptableObject.bulletType;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public float GetBulletDamage()
    {
        return bulletDamage;
    }

    public BulletType GetBulletType()
    {
        return bulletType;
    }
}
