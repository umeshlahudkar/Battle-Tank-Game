using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    EnemyModel enemyModel { get; }
    EnemyView enemyView { get; }

    EnemyTankState currentState;
    NavMeshAgent agent;
    Transform bulletSpwanPosition;
    Slider healthBar;

    public EnemyController(EnemyModel _enemyModel, EnemyTankScriptableObject _enemyTankScriptableObject)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyTankScriptableObject.enemyView);

        enemyView.transform.position = _enemyTankScriptableObject.PatrolPath.transform.GetChild(0).position;

        agent = enemyView.GetNavmeshAgent();
        bulletSpwanPosition = enemyView.GetBulletSpwanPosition();
        healthBar = enemyView.GetHealthBar();

        enemyModel.SetEnemyController(this);
        enemyView.SetEnemyController(this);
    }

    public void ProcessState()
    {
        currentState.Update();
    }

    public void ChangeState(TankState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = GetEnemyTankState(newState);
        currentState.Enter();
    }

    public EnemyTankState GetEnemyTankState(TankState newState)
    {
        EnemyTankState newTankState = null;

        switch(newState)
        {
            case TankState.Idle:
                newTankState = new EnemyIdleState(TankService.Instance.activePlayer.transform, enemyView.transform, agent, this, bulletSpwanPosition);
                break;

            case TankState.Patrol:
                newTankState = new EnemyPatrolState(TankService.Instance.activePlayer.transform, enemyView.transform, agent, this, bulletSpwanPosition);
                break;

            case TankState.Chase:
                newTankState = new EnemyChaseState(TankService.Instance.activePlayer.transform, enemyView.transform, agent, this, bulletSpwanPosition);
                break;

            case TankState.Attack:
                newTankState = new EnemyAttackState(TankService.Instance.activePlayer.transform, enemyView.transform, agent, this, bulletSpwanPosition);
                break;

            default:
                newTankState = null;
                break;
        }

        return newTankState;
    }

    public bool IsDead()
    {
        if(enemyModel.GetHealth() <= 0)
        {
            Disable();
            return true;
        }
        return false;
    }

    public void TakeDamage(float damage)
    {
        float health = enemyModel.GetHealth() - damage;
        enemyModel.SetHealth(health);
        UpdateHealthBar();
    }

    public void LookToward(Canvas sliderCanvas, Vector3 target)
    {
        sliderCanvas.transform.LookAt(target);
    }

    public void UpdateHealthBar()
    {
        healthBar.value = enemyModel.GetHealth();
    }

    public void Enable()
    {
        enemyView.transform.position = enemyModel.initialPosition;
        enemyModel.SetHealth(enemyModel.initialhealth);
        UpdateHealthBar();
        enemyView.Enable();
    }

    public void Disable()
    {
        enemyView.Disable();
        EnemyTankPool.enemyTankPool.ReturnTankToPool(this);
        EnemyService.Instance.DestroyEnemy(this);
        EventService.Instance.InvokeOnEnemyKillEvent();
    }

    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }

}
