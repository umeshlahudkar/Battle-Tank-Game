using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyTankState
{
    float currentTimeToFire ;
    public EnemyAttackState(Transform player, Transform enemy, NavMeshAgent agent, EnemyController _tankController, Transform _bulletSpwanPos)
                            : base(player, enemy, agent, _tankController, _bulletSpwanPos)
    {

    }

    public override void Enter()
    {
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {
        // Changing state into Idle state If Player is not in shooting range
        if (!CanFire())
        {
            enemyController.ChangeState(TankState.Idle);
            return;
        }

        Vector3 direction = player.position - enemy.position;

        enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(direction), Time.deltaTime);

        currentTimeToFire += Time.deltaTime;

        if(currentTimeToFire >= timeToFire)
        {
            FireBullet();
            currentTimeToFire = 0;
        }
     
    }

    public override void Exit()
    {
        agent.isStopped = false;
        base.Exit();
    }
}
