using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    private float bulletSpeed;
    private float bulletDamage;

    private float timeToDisable = 1;
    private float runningTime = 0 ;

    private void Start()
    {
        bulletSpeed = bulletController.GetBulletModel().GetBulletSpeed();
        bulletDamage = bulletController.GetBulletModel().GetBulletDamage();

    }

    void Update()
    {
        bulletController.BulletMove(bulletSpeed);

        runningTime += Time.deltaTime;
        if(runningTime >= timeToDisable)
        {
            bulletController.Disable();
            runningTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if(damagable != null)
        {
            damagable.TakeDamage((int)bulletDamage);
        }

        bulletController.Disable();
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }

    internal void Enable()
    {
        gameObject.SetActive(true);
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public BulletController GetBulletController()
    {
        return bulletController;
    }
}
