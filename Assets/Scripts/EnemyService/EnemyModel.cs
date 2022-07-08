using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    private EnemyController enemyController;

    public EnemyModel(EnemyTankScriptableObject scriptableObject)
    {

    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
}
