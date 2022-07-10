using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    EnemyModel enemyModel { get; }
    EnemyView enemyView { get; }

    private EnemyTankScriptableObject enemyTankScriptableObject;

    int index;

    public EnemyController(EnemyModel _enemyModel, EnemyTankScriptableObject _enemyTankScriptableObject)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyTankScriptableObject.enemyView);
        enemyView.transform.position = _enemyTankScriptableObject.PatrolPath.transform.GetChild(index).position;

        enemyTankScriptableObject = _enemyTankScriptableObject;

        enemyModel.SetEnemyController(this);
        enemyView.SetEnemyController(this);
    }

    public void Patrol(Vector3 currentPosition)
    {
        if (Vector3.Distance(currentPosition, enemyTankScriptableObject.PatrolPath.transform.GetChild(index).position) <= 2)
        {
            index++;
        }

        if (index >= enemyTankScriptableObject.PatrolPath.transform.childCount)
        {
            index = 0;
        }

        enemyView.GetNavmeshAgent().SetDestination(enemyTankScriptableObject.PatrolPath.transform.GetChild(index).position);
    }

    public void Chase(Vector3 targetPosition)
    {
        enemyView.GetNavmeshAgent().SetDestination(targetPosition);
    }

    public void FireBullet(Transform spwantransform)
    {
        BulletService.Instance.SpwanBullet(enemyModel.GetBulletType(), spwantransform);
    }

    public bool IsInRange(Vector3 currentPos)
    {
        return Vector3.Distance(TankService.Instance.activePlayer.transform.position, currentPos) < 10f;
    }

    public void TakeDamage(float damage)
    {
        float health = enemyModel.GetHealth() - damage;
        enemyModel.SetHealth(health);
    }

    public void LookToward(Canvas sliderCanvas, Vector3 target)
    {
        sliderCanvas.transform.LookAt(target);
    }

    public void UpdateHealthBar(Slider healthBar)
    {
        healthBar.value = enemyModel.GetHealth();
    }

    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }

}
