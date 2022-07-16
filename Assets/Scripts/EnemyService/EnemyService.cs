using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericMonoSingleton<EnemyService>
{
    [SerializeField] EnemyTankListScriptableObject enemyTankListScriptableObject;

    void Start()
    {
        for(int i = 0; i < enemyTankListScriptableObject.enemyTanks.Length; i++)
        {
            EnemyTankScriptableObject enemyTankScriptableObject = enemyTankListScriptableObject.enemyTanks[i];
            CreateEnemyTank(enemyTankScriptableObject);
        }
    }

    public void CreateEnemyTank(EnemyTankScriptableObject  _tankScriptableObject)
    {
        EnemyModel enemyModel = new EnemyModel(_tankScriptableObject);
        EnemyController enemyController = new EnemyController(enemyModel, _tankScriptableObject);
    }

}
