using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();      
    }

    void Update()
    {
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

    }

}
