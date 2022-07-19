using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPool
{
    public static TankPool tankPool = new TankPool();
    public class PoolItem
    {
        public EnemyView tankPrefab;
        //public EnemyController controller;
        public bool IsUsed;
        public TankType tankType;

    }

    public List<PoolItem> PooledTanks = new List<PoolItem>();
    public EnemyView GetTank(TankType tankType, EnemyView _tankPrefab)
    {
        if (PooledTanks.Count > 0)
        {
            for (int i = 0; i < PooledTanks.Count; i++)
            {
                if (PooledTanks[i].tankType == tankType && PooledTanks[i].IsUsed == false)
                {
                    PooledTanks[i].IsUsed = true;
                    return PooledTanks[i].tankPrefab;
                }
            }
        }
        return CreateNewTank(tankType, _tankPrefab);
    }

    private EnemyView CreateNewTank(TankType tankType, EnemyView _tankPrefab)
    {
        PoolItem newItem = new PoolItem();
        newItem.tankPrefab = GameObject.Instantiate(_tankPrefab);
        newItem.IsUsed = true;
        newItem.tankType = tankType;
        PooledTanks.Add(newItem);
        return newItem.tankPrefab;
    }

    public void ReturnTankToPool(EnemyView tank)
    {
        PoolItem poolBullet = PooledTanks.Find(item => item.tankPrefab.Equals(tank));
        poolBullet.IsUsed = false;
    }
}
