using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyTankState
{
    int index;
    public EnemyPatrolState(Transform player, Transform enemy, NavMeshAgent agent, EnemyController _tankController, Transform _bulletSpwanPos)
                            : base(player, enemy, agent, _tankController, _bulletSpwanPos)
    {

    }

    public override void Enter()
    {
        base.Enter();
        agent.speed = patrolSpeed;
    }

    public override void Update()
    {
        base.Update();

        if (CanChase())
        {
            enemyController.ChangeState(TankState.Chase);
            return;
        }

        if (Vector3.Distance(wayPoints.transform.GetChild(index).position, enemy.position) < 2f)
        {
            index++;
        }

        if (index >= wayPoints.transform.childCount)
        {
            index = 0;
        }

        agent.SetDestination(wayPoints.transform.GetChild(index).position);

    }

    public override void Exit()
    {
        base.Exit();
    }
}
