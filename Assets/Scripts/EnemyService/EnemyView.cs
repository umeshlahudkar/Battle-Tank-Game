using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    [SerializeField] Transform bulletSpwanPos;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Canvas sliderCanvas;
    [SerializeField] Slider healthBar;
    Camera mainCamera;

    public NavMeshAgent GetNavmeshAgent()
    {
        return navMeshAgent;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        healthBar.maxValue = enemyController.GetEnemyModel().GetHealth();
    }

    private void Update()
    {
        enemyController.LookToward(sliderCanvas, mainCamera.transform.position);

        if (enemyController.GetEnemyModel().GetHealth() > 0 && !TankService.Instance.isGameOver)
        {
            if (TankService.Instance.activePlayer != null && enemyController.IsInRange(gameObject.transform.position))
            {
                Chase();
            }
            else
            {
                Patrolling();
            }
        }
        else
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            enemyController.FireBullet(bulletSpwanPos);
        }
        
    }

    public void Patrolling()
    {
        enemyController.Patrol(gameObject.transform.position);
    }

    public void Chase()
    {
        enemyController.Chase(TankService.Instance.activePlayer.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletView>() != null)
        {
            enemyController.TakeDamage(enemyController.GetEnemyModel().GetDamageByPlayerBullet());
        }

        if (collision.gameObject.GetComponent<TankView>() != null)
        {
            enemyController.TakeDamage(enemyController.GetEnemyModel().GetDamageByPlayerTank());
        }

        enemyController.UpdateHealthBar(healthBar);
    }


}
