using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    float movement;
    float rotation;

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    void Start()
    {
       
    }

    void Update()
    {
        UserInput();

        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }

        if(rotation != 0)
        {
            tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
        }
    }

    private void UserInput()
    {
        movement = Input.GetAxis("Vertical1");
        rotation = Input.GetAxis("Horizontal1");
    }
}
