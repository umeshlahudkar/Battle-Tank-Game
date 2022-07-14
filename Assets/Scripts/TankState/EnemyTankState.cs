using UnityEngine;
using UnityEngine.AI;

public enum TankState
{
    Idle,
    Patrol,
    Chase,
    Attack
}

public class EnemyTankState
{
 
    protected Transform player;
    protected Transform enemy;
    protected NavMeshAgent agent;
    protected EnemyController enemyController;
    protected GameObject wayPoints;
    protected Transform bulletSpwanPos;

    protected float timeToFire;
    protected float chaseDistance;
    protected float fireDistance;
    protected float patrolSpeed;
    protected float chaseSpeed;

    public EnemyTankState(Transform _player, Transform _enemy, NavMeshAgent _agent, EnemyController _tankController, Transform _bulletSpwanPos)
    {
        player = _player;
        enemy = _enemy;
        agent = _agent;
        enemyController = _tankController;
        wayPoints = enemyController.GetEnemyModel().wayPoints;
        bulletSpwanPos = _bulletSpwanPos;

        timeToFire = enemyController.GetEnemyModel().GetFireTime();
        chaseDistance = enemyController.GetEnemyModel().GetChaseDistance();
        fireDistance = enemyController.GetEnemyModel().GetFireDistance();
        patrolSpeed = enemyController.GetEnemyModel().GetPatrolSpeed();
        chaseSpeed = enemyController.GetEnemyModel().GetChaseSpeed();
    }


    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }

    protected bool CanChase()
    {
        float distance = Vector3.Distance(player.position, enemy.position);
        if(distance < chaseDistance)
        {
            return true;
        }
        return false;
    }

    protected bool CanFire()
    {
        float distance = Vector3.Distance(player.position, enemy.position);
        if(distance < fireDistance)
        {
            return true;
        }
        return false;
    }

    protected void FireBullet()
    {
        BulletService.Instance.SpwanBullet(enemyController.GetEnemyModel().GetBulletType(), bulletSpwanPos);
    }
}

