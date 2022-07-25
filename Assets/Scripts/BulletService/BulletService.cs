using UnityEngine;

public class BulletService : GenericMonoSingleton<BulletService>
{
    public BulletListScriptableObject bulletList;

    public void FireBullet(BulletType bulletType, Transform fireTransform, TankController tankController)
    {
        CreateBullet(bulletType, fireTransform, tankController);
    }

    private void CreateBullet(BulletType bulletType, Transform fireTransform, TankController tankController)
    {
        BulletScriptableObject bulletScriptableObject = GetBulletScriptablObject(bulletType);
        BulletModel bulletModel = new BulletModel(bulletScriptableObject);
        BulletController bulletController = new BulletController(bulletType, bulletModel, fireTransform, bulletScriptableObject.bulletView, tankController);
    }

    public void FireBullet(BulletType bulletType, Transform fireTransform, EnemyController enemyController)
    {
        CreateBullet(bulletType, fireTransform, enemyController);
    }

    private void CreateBullet(BulletType bulletType, Transform fireTransform, EnemyController enemyController)
    {
        BulletScriptableObject bulletScriptableObject = GetBulletScriptablObject(bulletType);
        BulletModel bulletModel = new BulletModel(bulletScriptableObject);
        BulletController bulletController = new BulletController(bulletType, bulletModel, fireTransform, bulletScriptableObject.bulletView, enemyController);
    }

    private BulletScriptableObject GetBulletScriptablObject(BulletType bulletType)
    {
        BulletScriptableObject bulletScriptableObject;

        for(int i = 0; i < bulletList.bullets.Length; i++)
        {
            if(bulletList.bullets[i].bulletType == bulletType)
            {
                bulletScriptableObject = bulletList.bullets[i];
                return bulletScriptableObject;
            }
        }
        return null;
    }
}

public enum BulletType
{
    None,
    Red,
    Blue,
    Green
}
