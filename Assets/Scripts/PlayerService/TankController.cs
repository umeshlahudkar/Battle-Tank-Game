using UnityEngine;
using UnityEngine.UI;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private int bulletsCount;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);

        // For Updating Camera Position
        TankService.Instance.activePlayer = tankView;

        tankModel.setTankController(this);
        tankView.setTankController(this);

        EventService.Instance.OnBulletFire += UpdateBulletCount;
        EventService.Instance.OnEnemyKilled += UpdateEnemyKillCount;
    }

    public void UpdateBulletCount()
    {
        tankModel.bulletCounter++;
        AchievmentHandler.Instance.CheckForBulletAchievmentUnlock(tankModel.bulletCounter);
    }

    public void UpdateEnemyKillCount()
    {
        tankModel.enemyKillCount++;
        UIDisplay.Instance.DisplayEnemyKillText(tankModel.enemyKillCount);
        AchievmentHandler.Instance.CheckForEnemyKillAchievmentUnlock(tankModel.enemyKillCount);
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
        BulletService.Instance.SpwanBullet(tankModel.GetBulletType(), bulleteTransform);

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
