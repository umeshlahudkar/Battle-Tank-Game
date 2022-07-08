using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    private void Update()
    {
        Patrolling();
    }

    public void Patrolling()
    {
        enemyController.Patrol(gameObject.transform.position);
    }


}
