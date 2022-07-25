using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);

        // For Updating Camera Position
        TankService.Instance.activePlayer = tankView;

        tankModel.setTankController(this);
        tankView.setTankController(this);

        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        EventService.Instance.OnBulletFire += UpdateBulletCount;
        EventService.Instance.OnEnemyKilled += UpdateEnemyKillCount;
    }

    private void UnSubscribeEvent()
    {
        EventService.Instance.OnBulletFire -= UpdateBulletCount;
        EventService.Instance.OnEnemyKilled -= UpdateEnemyKillCount;
    }

    public void UpdateBulletCount()
    {
        tankModel.bulletCounter++;
        AchievmentHandler.Instance.CheckForBulletAchievmentUnlock(tankModel.bulletCounter);
    }

    public void UpdateEnemyKillCount()
    {
        tankModel.enemyKillCount++;
        UIDisplay.Instance.DisplayEnemyKill(tankModel.enemyKillCount);
        AchievmentHandler.Instance.CheckForEnemyKillAchievmentUnlock(tankModel.enemyKillCount);
    }

    public bool IsDead()
    {
        if(tankModel.GetHealth() <= 0)
        {
            TankService.Instance.isGameOver = true;
            UnSubscribeEvent();
            return true;
        }
        return false;
    }

    public void Move(float movement)
    {
        tankView.transform.Translate(Vector3.forward * movement * tankModel.GetMovementSpeed() * Time.deltaTime);
    }

    public void Rotate(float rotation)
    {
        tankView.transform.Rotate(0, rotation * tankModel.GetRotationSpeed() * Time.deltaTime , 0);
    }

    public void FireBullet(Transform bulleteTransform)
    {
        BulletService.Instance.CreateBullet(tankModel.GetBulletType(), bulleteTransform);

        EventService.Instance.InvokeOnBulletFireEvent();
    }

     public void TakeDamage(float damage)
    {
        float health = tankModel.GetHealth() - damage;
        tankModel.SetHealth(health);
    }

    public void LookToward(Canvas sliderCanvas , Vector3 target)
    {
        sliderCanvas.transform.LookAt(target);
    }

    public void UpdateHealthBar(Slider healthBar)
    {
        healthBar.value = tankModel.GetHealth();
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }

}
