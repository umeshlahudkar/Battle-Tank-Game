
using UnityEngine;


[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public float movementSpeed;
    public float rotationSpeed;
    public BulletType bulletType;
    public TankView tankView;
}


