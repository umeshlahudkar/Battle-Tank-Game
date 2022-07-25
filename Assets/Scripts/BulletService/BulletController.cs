using UnityEngine;
using System.Threading.Tasks;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }
    public TankController tankController { get; private set; }
    public EnemyController enemyController { get; private set; }
    Rigidbody rb;

    public BulletController(BulletType bulletType, BulletModel _bulletModel, Transform fireTransform, BulletView _bulletView, EnemyController enemyController)
    {
        bulletModel = _bulletModel;
        bulletView = BulletPool.Instance.GetBullet(bulletType, _bulletView);
        this.enemyController = enemyController;

        bulletView.transform.position = fireTransform.position;
        bulletView.transform.rotation = fireTransform.rotation;

        Enable();
        Initialize();
        SetBulletColour();

        rb = bulletView.GetRigidBody();
        rb.velocity = fireTransform.forward * enemyController.enemyModel.bulletLaunchForce;

        EventService.Instance.OnGamePause += GamePaused;
        EventService.Instance.OnGameResume += GameResumed;
        EventService.Instance.OnGameOver += Disable;
    }

    public BulletController(BulletType bulletType, BulletModel _bulletModel, Transform fireTransform, BulletView _bulletView, TankController tankController)
    {
        bulletModel = _bulletModel;
        bulletView = BulletPool.Instance.GetBullet(bulletType, _bulletView);
        this.tankController = tankController;

        bulletView.transform.position = fireTransform.position;
        bulletView.transform.rotation = fireTransform.rotation;

        Enable();
        Initialize();
        SetBulletColour();

        rb = bulletView.GetRigidBody();
        rb.velocity = fireTransform.forward * tankController.tankModel.bulletLaunchForce ;

        EventService.Instance.OnGamePause += GamePaused;
        EventService.Instance.OnGameResume += GameResumed;
        EventService.Instance.OnGameOver += Disable;
    }

    private void Initialize()
    {
        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);
    }

    public void Enable()
    {
        bulletView.enabled = true;
        bulletView.Enable();
    }

    public void GamePaused()
    {
        bulletModel.currentVelocity = bulletView.GetComponent<Rigidbody>().velocity;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
    }

    public void GameResumed()
    {
        rb.velocity = bulletModel.currentVelocity;
        rb.useGravity = true;
    }

    public  void Disable()
    {
        PlayBulletExplosionParticle();
        AudioManager.Instance.PlaySFXAudio(SoundType.BulletExplosion);
        bulletView.Disable();
        BulletPool.Instance.ReturnBulletToPool(bulletView);

        EventService.Instance.OnGamePause -= GamePaused;
        EventService.Instance.OnGameResume -= GameResumed;
        EventService.Instance.OnGameOver -= Disable;
    }

    public async void PlayBulletExplosionParticle()
    {
        ParticleSystem bulletSxplosion = ParticleSystemPool.Instance.GetParticleSystem(bulletModel.bulletExplosionParticle, ParticleSystemType.bulletExplosion);
        bulletSxplosion.transform.position = bulletView.transform.position;
        bulletSxplosion.gameObject.SetActive(true);
        bulletSxplosion.Play();

        await Task.Delay(System.TimeSpan.FromSeconds(1));

        bulletSxplosion.gameObject.SetActive(false);
        ParticleSystemPool.Instance.ReturnToPool(bulletSxplosion);
    }

    private void SetBulletColour()
    {
        MeshRenderer renderer = bulletView.GetComponent<MeshRenderer>();
        renderer.material.color = bulletModel.bulletColor;
    }
}
