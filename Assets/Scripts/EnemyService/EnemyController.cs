
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    public EnemyModel enemyModel { get; }
    public EnemyView enemyView { get; }

    private EnemyTankScriptableObject enemyTankScriptableObject;
    NavMeshAgent navMeshAgent;

    int index;

    public EnemyController(EnemyModel _enemyModel, EnemyTankScriptableObject _enemyTankScriptableObject)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyTankScriptableObject.enemyView);
        enemyView.transform.position = _enemyTankScriptableObject.WayPoints[index];

        navMeshAgent = enemyView.GetComponent<NavMeshAgent>();

        enemyTankScriptableObject = _enemyTankScriptableObject;

        enemyModel.SetEnemyController(this);
        enemyView.SetEnemyController(this);
    }

    public void Patrol(Vector3 currentPosition)
    {
        if( Vector3.Distance(currentPosition, enemyTankScriptableObject.WayPoints[index]) <= 3 ){
            index++;
        }

        if(index >= enemyTankScriptableObject.WayPoints.Length)
        {
            index = 0;
        }

        navMeshAgent.SetDestination(enemyTankScriptableObject.WayPoints[index]);
    }
}
