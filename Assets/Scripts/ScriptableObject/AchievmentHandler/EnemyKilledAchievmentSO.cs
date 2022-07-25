using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemyKillAchievmentScriptableObject", menuName = "ScriptableObject/Enemy Kill Achievment")]
public class EnemyKilledAchievmentSO : ScriptableObject
{
    public Achievment[] EnemyKillAchievment;

    [Serializable]
    public class Achievment
    {
        public enum EnemyKillAchievment
        {
            None,
            EliteKiller,
            AssassinKiller,
            SeniorKiller
        }

        public int requirement;
        public EnemyKillAchievment enemyKillAchievment;
        public string Name;
    }
}
