using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndreasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController CC;
    [SerializeField] private float speed = 4.0f;
    private float pivot;
    [SerializeField] float m_sensitivity = 4.0f;
    [SerializeField] float jumpForce = 100.0f;
    [SerializeField] float gravity = 25.0f;
    private bool jumped;
    private bool crouching;
    private Vector2 direction = new Vector2();
    private Vector3 movement;

    void Start()
    {
        jumped = false;
        crouching = false;
        pivot = transform.localRotation.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        Movement();
        Jump();
        Crouch();
        CC.Move(movement * speed * Time.deltaTime);
    }

    void Movement()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        direction.Normalize();

        //  pivot += Input.GetAxis("Mouse X") * m_sensitivity;
        //  transform.localRotation = Quaternion.Euler(0, pivot, 0);

        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);

        animator.SetBool("Moving", direction.sqrMagnitude > 0);

        movement = new Vector3(direction.x, 0, direction.y);
        if (direction.sqrMagnitude > 0)
        {
            movement = transform.rotation * movement;
        }
    }
    void Jump()
    {
        if (CC.isGrounded && Input.GetButton("Jump") && !jumped)
        {
            movement.y = jumpForce;
            animator.SetBool("Jumping", true);
            jumped = true;
            StartCoroutine(Jumped());
        }
        else if (CC.isGrounded)
        {
            movement.y = -1;
            animator.SetBool("Jumping", false);
        }
        movement.y -= gravity * Time.deltaTime;
    }

    void Crouch()
    {
        if (!Input.GetKey(KeyCode.C) && crouching)
        {
            StopCrouch();
            speed = 4.0f;
        }
        if (Input.GetKey(KeyCode.C) && !crouching)
        {
            StartCrouch();
            speed = 2.0f;
        }
    }

    IEnumerator Jumped()
    {
        if(jumped == true)
        {
            yield return new WaitForSeconds(1);
        }
        yield return null;
        jumped = false;

    }
    void StartCrouch()
    {
            animator.SetBool("Crouching", true);
            crouching = true;
    }
    void StopCrouch()
    {
            animator.SetBool("Crouching", false);
            crouching = false;
    }
    void gotHit()
    {
        animator.Play("Hit Reaction", 0, 0.2f);
    }
}
