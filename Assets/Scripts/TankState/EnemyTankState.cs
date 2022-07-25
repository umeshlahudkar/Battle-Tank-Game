using UnityEngine;
using UnityEngine.AI;

public class EnemyTankState
{
    protected Transform player;
    protected Transform enemy;
    protected NavMeshAgent agent;
    protected EnemyController enemyController;
    protected GameObject wayPoints;
    private Transform bulletSpwanPos;

    protected float timeToFire;
    private float chaseDistance;
    private float fireDistance;
    protected float patrolSpeed;
    protected float chaseSpeed;
    protected float bulletLaunchForce;

    public EnemyTankState(Transform _player, Transform _enemy, NavMeshAgent _agent, EnemyController _tankController, Transform _bulletSpwanPos)
    {
        player = _player;
        enemy = _enemy;
        agent = _agent;
        enemyController = _tankController;
        wayPoints = enemyController.enemyModel.wayPoints;
        bulletSpwanPos = _bulletSpwanPos;

        timeToFire = enemyController.enemyModel.timeToFire;
        chaseDistance = enemyController.enemyModel.chaseDistance;
        fireDistance = enemyController.enemyModel.fireDistance;
        patrolSpeed = enemyController.enemyModel.patrolSpeed;
        chaseSpeed = enemyController.enemyModel.chaseSpeed;
        bulletLaunchForce = enemyController.enemyModel.bulletLaunchForce;
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
        BulletService.Instance.FireBullet(enemyController.enemyModel.bulletType, bulletSpwanPos, enemyController);
    }
}

public enum TankState
{
    None,
    Idle,
    Patrol,
    Chase,
    Attack
}

