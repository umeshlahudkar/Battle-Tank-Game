using UnityEngine;

public class EnemyModel 
{
    public EnemyController enemyController { get; private set; }
    public BulletType bulletType { get; private set; }
    public float health { get; private set; }
    public GameObject wayPoints { get; private set; } // Storing the Waypoints for patroling the enemy
    public float timeToFire { get; private set; }
    public Vector3 initialPosition { get; private set; }
    public float chaseDistance { get; private set; }
    public float patrolSpeed { get; private set; }
    public float fireDistance { get; private set; }
    public float initialhealth { get; private set; }
    public float chaseSpeed { get; private set; }
    public float bulletLaunchForce { get; private set; }
    public Color tankColor { get; private set; }
    public ParticleSystem tankExplosionParticle { get; private set; }


    public EnemyModel(EnemyTankScriptableObject scriptableObject)
    {
        bulletType = scriptableObject.bulletType;
        health = initialhealth = scriptableObject.health;
        wayPoints = scriptableObject.PatrolPath;
        timeToFire = scriptableObject.timeToFire;
        chaseDistance = scriptableObject.chasingDistance;
        fireDistance = scriptableObject.firingDistance;
        patrolSpeed = scriptableObject.patrolSpeed;
        chaseSpeed = scriptableObject.chaseSpeed;
        initialPosition = scriptableObject.PatrolPath.transform.GetChild(0).position;
        bulletLaunchForce = scriptableObject.bulletLaunchForce;
        tankColor = scriptableObject.tankColor;
        tankExplosionParticle = scriptableObject.tankExplosionParticle;
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    
    public void SetHealth(float value)
    {
        health = Mathf.Max(0, value);
    }
}
