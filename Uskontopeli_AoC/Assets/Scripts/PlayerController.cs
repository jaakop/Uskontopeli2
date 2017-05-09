using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    public Image currentHealthBar;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensivity = 3f;

    [SerializeField]
    private Transform winCanvas;

    [SerializeField]
    public float maXHealth = 10f;
    public float currentHealth = 10f;

    public float healTimer = 20;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();      
    }

    void Update()
    {
        healTimer -= Time.deltaTime;

        if(healTimer < 0)
        {
            HealDamage(1f);
        }

        //Calculate movement velocity as 3d vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _yMov;

        //Final movemant vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movemant
        motor.Move(_velocity);

        //Calculate rotation as a 3D verctor (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D verctor (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);

        UpdateHealthBar();

    }

    void UpdateHealthBar()
    {
        float ratio = currentHealth / maXHealth;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("IsDead");

            winCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        healTimer = 20;
    }

    void HealDamage(float heal)
    {
        currentHealth += heal;
        if(currentHealth >= maXHealth)
        {
            currentHealth = maXHealth;
        }
        healTimer = 1;
    }

}
