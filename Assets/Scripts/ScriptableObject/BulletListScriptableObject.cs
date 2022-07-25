
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Bullet List")]
public class BulletListScriptableObject : ScriptableObject
{
    public BulletScriptableObject[] bullets;
}
