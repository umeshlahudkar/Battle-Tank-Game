using System.Collections.Generic;
using UnityEngine;

public class BulletPool 
{
   public static BulletPool bulletPool = new BulletPool();
   public class PoolItem
   {
        public BulletView bulletPrefab;
        public bool IsUsed;
        public BulletType bulletType;

   }

    public List<PoolItem> PooledBullets = new List<PoolItem>();
    public BulletView GetBullet(BulletType bulletType , BulletView _bulletprefab) 
    {
        if(PooledBullets.Count > 0)
        {
            for (int i = 0; i < PooledBullets.Count; i++)
            {
                if (PooledBullets[i].bulletType == bulletType && PooledBullets[i].IsUsed == false)
                {
                    PooledBullets[i].IsUsed = true;
                    return PooledBullets[i].bulletPrefab;
                }
            }
        }
        return CreateNewBullet(bulletType, _bulletprefab);
    }

    private BulletView CreateNewBullet(BulletType bulletType, BulletView _bulletprefab)
    {
        PoolItem newItem = new PoolItem();
        newItem.bulletPrefab = GameObject.Instantiate(_bulletprefab);
        newItem.IsUsed = true;
        newItem.bulletType = bulletType;
        PooledBullets.Add(newItem);
        return newItem.bulletPrefab;
    }

    public void ReturnBulletToPool(BulletView bullet)
    {
        PoolItem poolBullet = PooledBullets.Find(item => item.bulletPrefab.Equals(bullet));
        poolBullet.IsUsed = false;
    }
}
