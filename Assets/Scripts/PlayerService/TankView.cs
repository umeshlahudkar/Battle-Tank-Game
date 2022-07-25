using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour , IDamagable
{
    private TankController tankController;
    public float movementInput;
    public float rotationInput;

    [Header("Local Components")]
    [SerializeField] Transform bulletSpwanPos;
    [SerializeField] Canvas sliderCanvas;
    [SerializeField] Slider healthBar;
    [SerializeField] Rigidbody rb;

    [Header("Movement Clips")]
    public AudioSource movementAudioSource;
    public AudioClip tankIdleClip;
    public AudioClip tankMovementClip;
   
    void Start()
    {
        healthBar.maxValue = tankController.tankModel.playerHealth;
    }

    void Update()
    {
        if (tankController.IsDead())
        {
            tankController.Dead();
            return;
        }

        tankController.LookTowardCamera(sliderCanvas);

        movementInput = Input.GetAxis("Vertical1");
        rotationInput = Input.GetAxis("Horizontal1");
        tankController.PlayMovementSound();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tankController.FireBullet(bulletSpwanPos);
        }
    }

    private void FixedUpdate()
    {
        tankController.Move(movementInput, rb);
        tankController.Turn(rotationInput, rb);
    }


    public void TakeDamage(int damage)
    {
        tankController.TakeDamage(damage);
        tankController.UpdateHealthBar(healthBar);
    }

    public int GetHealth()
    {
        return (int)tankController.tankModel.playerHealth;
    }

    internal void Enable()
    {
        this.enabled = true;
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
