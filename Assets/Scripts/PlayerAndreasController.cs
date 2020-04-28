using UnityEngine;

[RequireComponent(typeof(PlayerAndreasMotor))]
public class PlayerAndreasController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lookSense = 3f;
    private PlayerAndreasMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerAndreasMotor>();
    }

    void Update()
    {   
        //Movement
        float _xMove = Input.GetAxisRaw("Horizontal"); // t ex (1,0,0)
        float _zMove = Input.GetAxisRaw("Vertical");  // t ex (0,0,1)

        Vector3 _moveHorizontal = transform.right * _xMove; // Creates Vector3
        Vector3 _moveVertical = transform.forward * _zMove; 

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed; // t ex (1,0,0) + (0,0,1) = (1,0,1)

        //Sent to Move which moves the Rigidbody in a FixedUpdate()
        motor.Move(_velocity);

        //Rotation
        //When we move mouse side to side, we rotate around the y-axis. 
        float _yRotation = Input.GetAxisRaw("Mouse X");

        //Only want to rotate the player horizontaly. Not vertically. The Camera is going to manage that.
        Vector3 _rotation = new Vector3(0f, _yRotation, 0f) * lookSense;

        //Apply rotation
        motor.Rotate(_rotation);

        //Camera Rotation
        //When we move mouse side to side, we rotate around the y-axis. 
        float _xRotation = Input.GetAxisRaw("Mouse Y");

        //Only want to rotate the player horizontaly. Not vertically. The Camera is going to manage that.
        Vector3 _cameraRotation = new Vector3(_xRotation,0f, 0f) * lookSense;

        //Apply rotation
        motor.RotateCamera(_cameraRotation);


    }
}
