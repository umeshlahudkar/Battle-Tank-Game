using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    public BulletController(BulletType bulletType, BulletModel _bulletModel, Transform bullet , BulletView _bulletView)
    {
        bulletModel = _bulletModel;
        bulletView = BulletPool.bulletPool.GetBullet(bulletType, _bulletView);

        bulletView.transform.position = bullet.position;
        bulletView.transform.rotation = bullet.rotation;

        Enable();

        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);
    }

    public void BulletMove(float speed)
    {
        bulletView.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Enable()
    {
        bulletView.Enable();
    }

    public void Disable()
    {
        bulletView.Disable();
        BulletPool.bulletPool.ReturnBulletToPool(bulletView);
    }
    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }

}
