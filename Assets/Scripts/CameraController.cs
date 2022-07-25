using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void LateUpdate()
    {
        if(TankService.Instance.activePlayer != null)
        {
            this.transform.position = TankService.Instance.activePlayer.transform.position;
        }
    }
}
