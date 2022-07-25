using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyTankState
{
    float timeElapced;
    public EnemyIdleState(Transform player, Transform enemy, NavMeshAgent agent, EnemyController _tankController, Transform _bulletSpwanPos)
                    : base(player, enemy, agent, _tankController, _bulletSpwanPos)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        timeElapced += Time.deltaTime;

        // Changing State after 2S from idle to Patrol state 
        if (timeElapced >= 2f)
        {
            enemyController.ChangeState(TankState.Patrol);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
