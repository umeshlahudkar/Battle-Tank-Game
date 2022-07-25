
using UnityEngine;

[CreateAssetMenu(fileName = "TankListScriptableObject", menuName = "ScriptableObject/List")]
public class TankListScriptableObject : ScriptableObject
{
    public TankScriptableObject[] tanks;
}

