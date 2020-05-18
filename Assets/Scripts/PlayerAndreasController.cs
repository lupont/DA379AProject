using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndreasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController CC;
    [SerializeField] private float speed = 5.0f;
    private float pivot;
    [SerializeField] float m_sensitivity = 4.0f;
    [SerializeField] float jumpSpeed = 8.0f;
    [SerializeField] float gravity = 20.0f;

    Vector2 direction = new Vector2();

    void Start()
    {
        pivot = transform.localRotation.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
      
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        direction.Normalize();

        pivot += Input.GetAxis("Mouse X") * m_sensitivity;
        transform.localRotation = Quaternion.Euler(0, pivot, 0);

        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);

        animator.SetBool("Moving", direction.sqrMagnitude > 0);

        Vector3 movement = new Vector3(direction.x, 0, direction.y);
        if (direction.sqrMagnitude > 0)
        {
            movement = transform.rotation * movement;
        }
        if(CC.isGrounded && Input.GetButton("Jump"))
        {
            movement.y = jumpSpeed;
            
        }
        movement.y -= gravity * Time.deltaTime;
        CC.Move(movement * speed * Time.deltaTime);
    }
}
