using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemyKillAchievmentScriptableObject", menuName = "ScriptableObject/Bullet Fire Achievment")]
public class BulletAchievmentSO : ScriptableObject
{
    public Achievment[] BulletFireAchievment;

    [Serializable]
    public class Achievment
    {
        public enum BulletFireAchievment
        {
            None,
            SharpShooter,
            WeaponMaster,
            WeaponMastry
        }

        public int requirement;
        public BulletFireAchievment bulletAchievment;
        public string Name;
    }
}
