using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyService : GenericMonoSingleton<EnemyService>
{
    [SerializeField] EnemyTankListScriptableObject enemyTankListScriptableObject;

    // Storing EnemyController of Active enemy in the scene
    private List<EnemyController> activeEnemy = new List<EnemyController>();

    void Start()
    {
        SpwanEnemyWave();
    }

    // Spwan Enemy Wave
    public void SpwanEnemyWave()
    {
        for (int i = 0; i < enemyTankListScriptableObject.enemyTanks.Length; i++)
        {
            EnemyTankScriptableObject enemyTankScriptableObject = enemyTankListScriptableObject.enemyTanks[i];
            EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
            EnemyController enemyController = EnemyTankPool.Instance.GetEnemyTank(enemyModel, enemyTankScriptableObject);
            activeEnemy.Add(enemyController);
            enemyController.Enable();
        }
    }

    // After Enemy dies, removing from the activeEnemy list , if the count is zero and Game is not Over then spwaning new wave
    public async void DestroyEnemy(EnemyController enemyController)
    {
        for(int i = 0; i < activeEnemy.Count; i++)
        {
            if(activeEnemy[i] == enemyController)
            {
                activeEnemy.RemoveAt(i);
            }
        }

        if(activeEnemy.Count <= 0 && TankService.Instance.isGameOver == false)
        {
            UIDisplay.Instance.DisplayWaitTime();
            await Task.Delay(TimeSpan.FromSeconds(3));
            SpwanEnemyWave();
        }
    }

}
