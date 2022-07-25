using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyService : GenericMonoSingleton<EnemyService>
{
    [SerializeField] EnemyTankListScriptableObject enemyTankListScriptableObject;

    private List<EnemyController> activeEnemy = new List<EnemyController>();

    void Start()
    {
        SpwanEnemyWave();
    }

    public void SpwanEnemyWave()
    {
        for (int i = 0; i < enemyTankListScriptableObject.enemyTanks.Length; i++)
        {
            EnemyTankScriptableObject enemyTankScriptableObject = enemyTankListScriptableObject.enemyTanks[i];
            EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
            EnemyController enemyController = EnemyTankPool.enemyTankPool.GetEnemyTank(enemyModel, enemyTankScriptableObject);
            activeEnemy.Add(enemyController);
            enemyController.Enable();
        }
    }

    public async void DestroyEnemy(EnemyController enemyController)
    {
        for(int i = 0; i < activeEnemy.Count; i++)
        {
            if(activeEnemy[i] == enemyController)
            {
                activeEnemy.RemoveAt(i);
            }
        }

        if(activeEnemy.Count <= 0)
        {
            UIDisplay.Instance.DisplaySpwaning();
            await Task.Delay(TimeSpan.FromSeconds(3));
            SpwanEnemyWave();
        }
    }

}
