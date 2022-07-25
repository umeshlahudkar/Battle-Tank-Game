using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    TankController tankController;
    float movementSpeed;
    float rotationSpeed;
    BulletType tankBulletType;
    float playerHealth;
    float damageByEnemyTank;
    float damageByEnemyBullet;

    public TankModel(TankScriptableObject scriptableObject)
    {
        movementSpeed = scriptableObject.movementSpeed;
        rotationSpeed = scriptableObject.rotationSpeed;
        tankBulletType = scriptableObject.bulletType;
        playerHealth = scriptableObject.health;
        damageByEnemyTank = scriptableObject.damageByEnemy;
        damageByEnemyBullet = scriptableObject.damageByBullet;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }

    public float GetHealth()
    {
        return playerHealth;
    }

    public BulletType GetBulletType()
    {
        return tankBulletType; ;
    }

    public float GetDamageByEnemyTank()
    {
        return damageByEnemyTank;
    }

    public float GetDamageByEnemyBullet()
    {
        return damageByEnemyBullet;
    }

    public void SetHealth(float value)
    {
        playerHealth = Mathf.Max(0, value);
    }
}
