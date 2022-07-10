
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    private float bulletSpeed;

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public BulletModel(float speed )
    {
        bulletSpeed = speed;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}
