using UnityEngine;


[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/Enemy Tank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public float movementSpeed;
    public float rotationSpeed;
    public float health;
    public float chaseSpeed;
    public float patrolSpeed;
    public float firingDistance;
    public float chasingDistance;
    public float timeToFire;
    public float bulletLaunchForce;
    public Color tankColor;
    public BulletType bulletType;
    public EnemyView enemyView;
    public GameObject PatrolPath;
    public ParticleSystem tankExplosionParticle;
}
