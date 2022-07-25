using UnityEngine;


[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/Enemy Tank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public Vector3[] WayPoints;
    public float movementSpeed;
    public float rotationSpeed;
    public BulletType bulletType;
    public EnemyView enemyView;
}
