using UnityEngine;


[CreateAssetMenu(fileName = "EnemyTankListScriptableObject", menuName = "ScriptableObject/EnemyTank List")]
public class EnemyTankListScriptableObject : ScriptableObject
{
    public EnemyTankScriptableObject[] enemyTanks;
}
