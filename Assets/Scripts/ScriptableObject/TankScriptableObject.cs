
using UnityEngine;


[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public float damageByEnemy;
    public float damageByBullet;
    public float health;
    public float movementSpeed;
    public float rotationSpeed;
    public BulletType bulletType;
    public TankView tankView;
}


