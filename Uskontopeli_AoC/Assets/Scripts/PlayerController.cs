using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Player;

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

    public PlayerMotor motor;

    void Awake()
    {
        Player = this; 
    }

    void Update()
    {
        if ((healTimer -= Time.deltaTime) < 0)
            HealDamage(1);

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
        Vector3 _rotation = new Vector3(0f, _yRot * lookSensivity);

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D verctor (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot * lookSensivity, 0f);

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float ratio = currentHealth / maXHealth;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        if ((currentHealth -= damage) <= 0)
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
        currentHealth = Mathf.Min(currentHealth + heal, maXHealth);
        healTimer = 1;
    }
}
