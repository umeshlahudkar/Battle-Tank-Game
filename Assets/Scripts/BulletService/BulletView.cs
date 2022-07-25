using System;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    //[SerializeField] ParticleSystem bulletDestroyParticleEffect;
    [SerializeField] Rigidbody rb;
    private float bulletDamage;

    private void Start()
    {
        bulletDamage = bulletController.bulletModel.bulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.TakeDamage((int)bulletDamage);
            int targetHealth = damagable.GetHealth();
            if (targetHealth <= 0)
            {
                if (bulletController.tankController != null)
                    bulletController.tankController.UpdateEnemyKillCount();
            }
        }

        bulletController.Disable();
    }

    internal Rigidbody GetRigidBody()
    {
        return rb;
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
}
