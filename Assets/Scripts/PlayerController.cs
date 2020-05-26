using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 8;
    [SerializeField] private float gravity = 40;
    [SerializeField] private float jumpForce = 10;

    private float speed;
    private float y_velocity;
    private Vector3 movement = Vector3.zero;

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        checkRun();

        movement = (transform.right * moveHorizontal + moveVertical * transform.forward);
        movement *= speed;

        animator.SetFloat("DirectionX", moveHorizontal);
        animator.SetFloat("DirectionY", moveVertical);
        animator.SetBool("Moving", movement.sqrMagnitude > 0);


        if (controller.isGrounded && Input.GetKey(KeyCode.Space)) {
            y_velocity = jumpForce;
        }
       
        controller.Move(movement * Time.deltaTime);
    }

    // Lägg på lite gravitaion om guppen har hoppat
    private void FixedUpdate() {
        controller.Move(new Vector3(0, y_velocity * Time.deltaTime));
        y_velocity  -= gravity * Time.deltaTime;
    }

    private void checkRun() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
        }
        else {
            speed = walkSpeed;
        }
    }
}
