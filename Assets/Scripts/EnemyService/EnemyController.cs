using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class EnemyController
{
    public EnemyModel enemyModel { get; private set; }
    public EnemyView enemyView { get; private set; }

    EnemyTankState currentState;
    NavMeshAgent agent;
    Transform bulletSpwanPosition;
    Slider healthBar;
    Canvas sliderCanvas;

    public EnemyController(EnemyModel _enemyModel, EnemyTankScriptableObject _enemyTankScriptableObject)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyTankScriptableObject.enemyView);

        enemyView.transform.position = _enemyTankScriptableObject.PatrolPath.transform.GetChild(0).position;

        healthBar = enemyView.GetHealthbar();
        enemyModel.SetEnemyController(this);
        enemyView.SetEnemyController(this);
        SetTankColour();
    }

    public void SubscribeEvent()
    {
        EventService.Instance.OnGamePause += GamePaused;
        EventService.Instance.OnGameResume += GameResumed;
        EventService.Instance.OnGameOver += Disable;
    }

    public void UnsubscribeEvent()
    {
        EventService.Instance.OnGamePause -= GamePaused;
        EventService.Instance.OnGameResume -= GameResumed;
        EventService.Instance.OnGameOver -= Disable;
    }

    public void GamePaused()
    {
        // On Pause button Click, Disabling EnemyView Script (So that it can't Move)
        enemyView.enabled = false;
    }

    public void GameResumed()
    {
        // On Resume button Click, Enabling EnemyView Script
        enemyView.enabled = true;
    }

    public void InitializeComponent(NavMeshAgent agent, Transform bulletSpwanPosition, Slider healthBar, Canvas sliderCanvas)
    {
        // Initialize Local Component
        this.agent = agent;
        this.bulletSpwanPosition = bulletSpwanPosition;
        this.healthBar = healthBar;
        this.sliderCanvas = sliderCanvas;
    }

    public void ProcessState()
    {
        // Runs the Update() function of State Machine every Frame
        currentState.Update();
    }

    // Change the current state acording to condition
    public void ChangeState(TankState newState)
    {
        if(currentState != null)
        {
            // Exit from the current active state
            currentState.Exit();
        }

        currentState = GetEnemyTankState(newState);
        // After changing state Runs the Enter() function of the New state
        currentState.Enter();
    }

    // Return the New tank state based on input
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

    // Check the Enemy health
    public bool IsDead()
    { 
        return (enemyModel.health <= 0);
    }

    // Reduce health by the amount of damage taken
    public void TakeDamage(float damage)
    {
        float health = enemyModel.health - damage;
        enemyModel.SetHealth(health);
        UpdateHealthBar();
    }

    // health bar looking toward the Main camera
    public void LookToward()
    {
        sliderCanvas.transform.LookAt(Camera.main.transform.position);
    }

    // Update Health Bar based on Enemy health
    public void UpdateHealthBar()
    {
        healthBar.value = enemyModel.health;
    }

    public void Enable()
    {
        SubscribeEvent();
        enemyView.transform.position = enemyModel.initialPosition;
        enemyModel.SetHealth(enemyModel.initialhealth);
        UpdateHealthBar();
        enemyView.Enable();
    }

    // this function runs after Enemy dies / health <= 0
    public void Disable()
    {
        PlayTankExplosion();
        AudioManager.Instance.PlaySFXAudio(SoundType.TankExplosion);
        enemyView.Disable();
        EnemyTankPool.Instance.ReturnTankToPool(this);
        EnemyService.Instance.DestroyEnemy(this);

        UnsubscribeEvent();
    }

    // Gets the Perticular Particle system From the Pool , plays particle system at tank position and return to pool after some period of time
    public async void  PlayTankExplosion()
    {
        ParticleSystem tankExplosionParticle = ParticleSystemPool.Instance.GetParticleSystem(enemyModel.tankExplosionParticle, ParticleSystemType.tankExplosion);
        tankExplosionParticle.transform.position = enemyView.transform.position;
        tankExplosionParticle.gameObject.SetActive(true);
        tankExplosionParticle.Play();

        await Task.Delay(System.TimeSpan.FromSeconds(1.5));

        tankExplosionParticle.gameObject.SetActive(false);
        ParticleSystemPool.Instance.ReturnToPool(tankExplosionParticle);
    }

    // Change the tank colour
    private void SetTankColour()
    {
        MeshRenderer[] renderer = enemyView.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderer.Length; i++)
        {
            renderer[i].material.color = enemyModel.tankColor;
        }
    }

}
