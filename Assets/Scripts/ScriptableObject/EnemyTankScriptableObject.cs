using UnityEngine;


[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/Enemy Tank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public float movementSpeed;
    public float rotationSpeed;
    public float health;
    public float damageByEnemy;
    public float damageByBullet;
    public BulletType bulletType;
    public EnemyView enemyView;
    public GameObject PatrolPath;
}
