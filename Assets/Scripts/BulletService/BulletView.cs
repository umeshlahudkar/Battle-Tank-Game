using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    private float bulletSpeed;
    private float timeToDisable = 1;
    private float runningTime = 0 ;
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    private void Start()
    {
        bulletSpeed = bulletController.GetBulletModel().GetBulletSpeed();
    }

    void Update()
    {
        bulletController.BulletMove(bulletSpeed);
        runningTime += Time.deltaTime;
        if(runningTime >= timeToDisable)
        {
            Destroy(gameObject);
            runningTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public BulletController GetBulletController()
    {
        return bulletController;
    }
}
