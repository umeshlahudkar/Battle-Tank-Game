using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankPool
{
    public static EnemyTankPool enemyTankPool = new EnemyTankPool();
    public class PoolItem
    {
        public EnemyController controller;
        public bool IsUsed;
    }

    public List<PoolItem> PooledTanks = new List<PoolItem>();
    public EnemyController GetEnemyTank(EnemyModel enemyModel, EnemyTankScriptableObject enemyTankScriptableObject)
    {
        if (PooledTanks.Count > 0)
        {
            for (int i = 0; i < PooledTanks.Count; i++)
            {
                if (PooledTanks[i].IsUsed == false)
                {
                    PooledTanks[i].IsUsed = true;
                    return PooledTanks[i].controller;
                }
            }
        }
        return CreateNewTank(enemyModel, enemyTankScriptableObject);
    }

    private EnemyController CreateNewTank(EnemyModel enemyModel, EnemyTankScriptableObject enemyTankScriptableObject)
    {
        PoolItem newItem = new PoolItem();
        newItem.controller = new EnemyController(enemyModel, enemyTankScriptableObject);
        newItem.IsUsed = true;
        PooledTanks.Add(newItem);
        return newItem.controller;
    }

    public void ReturnTankToPool(EnemyController tank)
    {
        PoolItem poolBullet = PooledTanks.Find(item => item.controller.Equals(tank));
        poolBullet.IsUsed = false;
    }
}
