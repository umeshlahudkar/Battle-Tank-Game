using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    public BulletController(BulletModel _bulletModel,Transform bullet ,BulletView _bulletView)
    {
        bulletModel = _bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView, bullet.position, bullet.rotation);

        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);
    }

    public void BulletMove(float speed)
    {
        bulletView.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }

}
