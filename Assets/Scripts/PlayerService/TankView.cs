using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour , IDamagable
{
    private TankController tankController;
    public Transform bulletSpwanPos;
    float movement;
    float rotation;
    [SerializeField] Canvas sliderCanvas;
    [SerializeField] Slider healthBar;
    Camera mainCamera;
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    void Start()
    {
        mainCamera = Camera.main;
        healthBar.maxValue = tankController.GetTankModel().GetHealth();
    }

    void Update()
    {
        tankController.LookToward(sliderCanvas, mainCamera.transform.position);

        if(tankController.GetTankModel().GetHealth() <= 0)
        {
            TankService.Instance.isGameOver = true;
            Destroy(gameObject);
            return;
        }

        UserInput();

        if(movement != 0)
        {
            tankController.Move(movement);
        }

        if(rotation != 0)
        {
            tankController.Rotate(rotation);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            tankController.FireBullet(bulletSpwanPos);
        }
    }

    private void UserInput()
    {
        movement = Input.GetAxis("Vertical1");
        rotation = Input.GetAxis("Horizontal1");
    }

    public void TakeDamage(int damage)
    {
        tankController.TakeDamage(damage);
        tankController.UpdateHealthBar(healthBar);
    }
}
