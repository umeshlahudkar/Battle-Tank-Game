using UnityEngine;

public class TankModel
{
    public Color tankColor { get; private set; }
    public TankController tankController { get; private set; }
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    public BulletType tankBulletType { get; private set; }
    public float playerHealth { get; private set; }
    public int bulletCount { get; set; }
    public int enemyKillCount { get; set; }
    public float bulletLaunchForce { get; private set; }
    public ParticleSystem tankExplosionParticle { get; private set; }
    public GameDataScriptableObject gameDataScriptable { get; private set; }

    public TankModel(TankScriptableObject scriptableObject, GameDataScriptableObject gameDataScriptableObject)
    {
        movementSpeed = scriptableObject.movementSpeed;
        rotationSpeed = scriptableObject.rotationSpeed;
        tankBulletType = scriptableObject.bulletType;
        playerHealth = scriptableObject.health;
        bulletLaunchForce = scriptableObject.bulletLaunchForce;
        tankColor = scriptableObject.tankColor;
        tankExplosionParticle = scriptableObject.tankExplosionParticle;
        gameDataScriptable = gameDataScriptableObject;
        gameDataScriptable.ResetData();
        //ResetData();
    }

    public void UpdateBulletCount()
    {
        gameDataScriptable.playerBulletFireCount++;
    }

    public void UpdateEnemyKilledCount()
    {
        gameDataScriptable.playerEnemyKilledCount++;
    }

    public void ResetData()
    {
        gameDataScriptable.playerBulletFireCount = 0;
        gameDataScriptable.playerEnemyKilledCount = 0;
        gameDataScriptable.playerScore = 0;
    }

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public void SetHealth(float value)
    {
        playerHealth = Mathf.Max(0, value);
    }
}
