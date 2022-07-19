using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour , IDamagable 
{
    private EnemyController enemyController;
    [SerializeField] Transform bulletSpwanPos;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Canvas sliderCanvas;
    [SerializeField] Slider healthBar;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        healthBar.maxValue = enemyController.GetEnemyModel().GetHealth();

        enemyController.ChangeState(TankState.Idle);
    }

    private void Update()
    {
        if(!enemyController.IsDead() && !TankService.Instance.isGameOver)
        {
            enemyController.LookToward(sliderCanvas, mainCamera.transform.position);
            enemyController.ProcessState();
        }
    }
    public NavMeshAgent GetNavmeshAgent()
    {
        return navMeshAgent;
    }

    public Transform GetBulletSpwanPosition()
    {
        return bulletSpwanPos;
    }

    public Slider GetHealthBar()
    {
        return healthBar;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }

    internal void Enable()
    {
        gameObject.SetActive(true);
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }
}
