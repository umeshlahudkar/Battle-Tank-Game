using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievmentHolderScriptableObject", menuName = "ScriptableObject/Achievment Holder")]
public class AchievmentHolderSO : ScriptableObject
{
    public BulletAchievmentSO bulletAchievmentSO;
    public EnemyKilledAchievmentSO enemyKilledAchievmentSO;
}
