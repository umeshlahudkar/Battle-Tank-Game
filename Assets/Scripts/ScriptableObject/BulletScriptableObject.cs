using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Bullet")]
public class BulletScriptableObject : ScriptableObject
{
    public float speed;
    public BulletType bulletType;
    public BulletView bulletView;
    public float bulletDamage;
}
