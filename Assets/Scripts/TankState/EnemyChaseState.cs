using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyTankState
{
    public EnemyChaseState(Transform player, Transform enemy, NavMeshAgent agent, EnemyController _tankController, Transform _bulletSpwanPos)
                            : base(player, enemy, agent, _tankController, _bulletSpwanPos)
    {

    }

    public override void Enter()
    {
        base.Enter();
        agent.speed = chaseSpeed;
    }

    public override void Update()
    {
        if (CanFire())
        {
            enemyController.ChangeState(TankState.Attack);
            return;
        }

        if(!CanChase())
        {
            enemyController.ChangeState(TankState.Patrol);
            return;
        }

        agent.SetDestination(player.position);

    }

    public override void Exit()
    {
        agent.speed = patrolSpeed;
        base.Exit();
    }

}
