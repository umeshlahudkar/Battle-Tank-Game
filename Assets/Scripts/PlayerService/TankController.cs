using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        SetTankColour();

        // For Updating Camera Position
        TankService.Instance.activePlayer = tankView;

        tankModel.setTankController(this);
        tankView.setTankController(this);

        EventService.Instance.OnGamePause += GamePaused;
        EventService.Instance.OnGameResume += GameResumed;
        EventService.Instance.OnGameOver += Disable;
    }

    // Total bullets Fire
    public void UpdateBulletCount()
    {
        tankModel.UpdateBulletCount();
    }

    // Update Enemy kill Count
    public void UpdateEnemyKillCount()
    {
        tankModel.UpdateEnemyKilledCount();
        EventService.Instance.InvokeOnEnemyKilledEvent();
    }

    //Mute Audio source and disable tanview On Game Paused
    public void GamePaused()
    {
        tankView.movementAudioSource.mute = true;
        tankView.enabled = false;
    }

    //Unmute audio source and Enable tankView On Game Resumed
    public void GameResumed()
    {
        tankView.movementAudioSource.mute = false;
        tankView.enabled = true;
    }

    // Checks Players Health
    public bool IsDead()
    {
       return (tankModel.playerHealth <= 0);
    }

    // Player Movement
    public void Move(float movement, Rigidbody rb)
    {
        Vector3 direction = tankView.transform.forward * movement * tankModel.movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + direction);
    }

    //Player Turn
    public void Turn(float rotation, Rigidbody rb)
    {
        float rotationAngle = rotation * tankModel.rotationSpeed * Time.fixedDeltaTime;
        Quaternion rotate = Quaternion.Euler(0, rotationAngle, 0);
        rb.MoveRotation(rb.rotation * rotate);
    }

    public void FireBullet(Transform bulleteTransform)
    {
        BulletService.Instance.FireBullet(tankModel.tankBulletType, bulleteTransform , this);
        AudioManager.Instance.PlaySFXAudio(SoundType.BulletFire);
        UpdateBulletCount();
        EventService.Instance.InvokeOnBulletFireEvent();
    }

    // Reduce health after taking some damage
    public void TakeDamage(float damage)
    {
        float health = tankModel.playerHealth - damage;
        tankModel.SetHealth(health);
    }

    //Health bar face toward the main camera
    public void LookTowardCamera(Canvas sliderCanvas)
    {
        sliderCanvas.transform.LookAt(Camera.main.transform.position);
    }

    //Update Health Bar
    public void UpdateHealthBar(Slider healthBar)
    {
        healthBar.value = tankModel.playerHealth;
    }

    public void Enable()
    {
        tankView.Enable();
    }

    public  void Disable()
    {
        PlayTankExplosionParticle();
        AudioManager.Instance.PlaySFXAudio(SoundType.TankExplosion);
        tankView.Disable();
        
        EventService.Instance.OnGamePause += GamePaused;
        EventService.Instance.OnGameResume += GameResumed;
        EventService.Instance.OnGameOver += Disable;
    }

    // Set tank colour
    private void SetTankColour()
    {
        MeshRenderer[] renderer = tankView.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderer.Length; i++)
        {
            renderer[i].material.color = tankModel.tankColor;
        }
    }

    // Plays tankIdle and tankMoving Sound clip
    public void PlayMovementSound()
    {
        if(Mathf.Abs(tankView.movementInput) >= 0.4f || Mathf.Abs(tankView.rotationInput) >= 0.4f)
        {
            
            if(tankView.movementAudioSource.clip == tankView.tankIdleClip)
            {
                tankView.movementAudioSource.clip = tankView.tankMovementClip;
                tankView.movementAudioSource.Play();
            }
        }
        else
        {
            if (tankView.movementAudioSource.clip == null || tankView.movementAudioSource.clip == tankView.tankMovementClip)
            {
                tankView.movementAudioSource.clip = tankView.tankIdleClip;
                tankView.movementAudioSource.Play();
            }
        }
    }

    public void Dead()
    {
        TankService.Instance.isGameOver = true;
        EventService.Instance.InvokeOnGameOverEvent();
    }

    //Gets tankExplosion particle system , plays the particlesystem at tank position and return to the pool after some time
    public async void PlayTankExplosionParticle()
    {
        ParticleSystem tankExplosion = ParticleSystemPool.Instance.GetParticleSystem(tankModel.tankExplosionParticle, ParticleSystemType.tankExplosion);
        tankExplosion.transform.position = tankView.transform.position;
        tankExplosion.gameObject.SetActive(true);
        tankExplosion.Play();

        await Task.Delay(System.TimeSpan.FromSeconds(1.5));

        tankExplosion.gameObject.SetActive(false);
        ParticleSystemPool.Instance.ReturnToPool(tankExplosion);
    }
}
