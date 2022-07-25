using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    EnemyController enemyController;
    BulletType bulletType;
    float damageByPlayerTank;
    float damageByPlayerBullet;
    float health;


    public EnemyModel(EnemyTankScriptableObject scriptableObject)
    {
        bulletType = scriptableObject.bulletType;
        damageByPlayerTank = scriptableObject.damageByEnemy;
        damageByPlayerBullet = scriptableObject.damageByBullet;
        health = scriptableObject.health;
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public void SetHealth(float value)
    {
        health = Mathf.Max(0, value);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetDamageByPlayerTank()
    {
        return damageByPlayerTank;
    }
    public float GetDamageByPlayerBullet()
    {
        return damageByPlayerBullet;
    }

    public BulletType GetBulletType()
    {
        return bulletType;
    }
}
