using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb = tankView.GetComponent<Rigidbody>();

        tankModel.setTankController(this);
        tankView.setTankController(this);
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed ;
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        tankView.transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime , 0);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

}
