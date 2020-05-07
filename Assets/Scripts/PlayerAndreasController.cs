using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndreasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController CC;
    [SerializeField] private float speed = 5;
    private float pivot;
    [SerializeField] float m_sensitivity = 4;

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

        if (direction.sqrMagnitude > 0)
        {
            Vector3 movement = new Vector3(direction.x, 0, direction.y);
            movement = transform.rotation * movement;
            CC.Move(movement * speed * Time.deltaTime);
        }
    }
}
