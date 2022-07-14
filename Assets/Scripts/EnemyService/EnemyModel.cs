using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    EnemyController enemyController;
    BulletType bulletType;
    float health;
    public GameObject wayPoints;
    float timeToFire;
    float chaseDistance;
    float fireDistance;
    float patrolSpeed;
    float chaseSpeed;


    public EnemyModel(EnemyTankScriptableObject scriptableObject)
    {
        bulletType = scriptableObject.bulletType;
        health = scriptableObject.health;
        wayPoints = scriptableObject.PatrolPath;
        timeToFire = scriptableObject.timeToFire;
        chaseDistance = scriptableObject.chasingDistance;
        fireDistance = scriptableObject.firingDistance;
        patrolSpeed = scriptableObject.patrolSpeed;
        chaseSpeed = scriptableObject.chaseSpeed;
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public void SetHealth(float value)
    {
        health = Mathf.Max(0, value);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetFireTime()
    {
        return timeToFire;
    }
    public float GetChaseDistance()
    {
        return chaseDistance;
    }
    public float GetChaseSpeed()
    {
        return chaseSpeed;
    }
    public float GetPatrolSpeed()
    {
        return patrolSpeed;
    }
    public float GetFireDistance()
    {
        return fireDistance;
    }

    public BulletType GetBulletType()
    {
        return bulletType;
    }
}
