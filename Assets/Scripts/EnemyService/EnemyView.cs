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

    private void Start()
    {
        enemyController.InitializeComponent(navMeshAgent, bulletSpwanPos, healthBar, sliderCanvas);
        healthBar.maxValue = enemyController.enemyModel.health;
        enemyController.ChangeState(TankState.Idle);
    }

    private void Update()
    {
        if(!enemyController.IsDead())
        {
            enemyController.LookToward();
            enemyController.ProcessState();
            return;
        }

        enemyController.Disable();
    }
   
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }

    public int GetHealth()
    {
        return (int)enemyController.enemyModel.health;
    }

    public Slider GetHealthbar()
    {
        return healthBar;
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
