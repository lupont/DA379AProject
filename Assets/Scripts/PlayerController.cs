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
<<<<<<< HEAD
    [SerializeField] private Transform gun;
=======
>>>>>>> 242cca32955ead71c54f06af19fef2144eaffb8c

    private float speed;
    private float y_velocity;
    private bool crouching = false;
    private Vector3 movement = Vector3.zero;
    private Vector3 crouch;
    private Vector3 stand;
    private float smooth = 100;

    private void Start() {
        crouch = new Vector3(gun.localPosition.x, 0.75f, gun.localPosition.z);
        stand = new Vector3(gun.localPosition.x, 1.3f, gun.localPosition.z);
        
    }

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        checkRun();
        checkCrouch();

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

    private void checkCrouch() {
        if (!Input.GetKey(KeyCode.C) && crouching) {
            StopCrouch();
            speed = 4.0f;
        }
        if (Input.GetKey(KeyCode.C) && !crouching) {
            StartCrouch();
            speed = 2.0f;
        }
    }

    private void StartCrouch() {
        animator.SetBool("Crouching", true);
        // gun.localPosition = Vector3.Lerp(stand, crouch, Time.deltaTime * 100f);
        crouching = true;
    }
    private void StopCrouch() {
        animator.SetBool("Crouching", false);
        // gun.localPosition = Vector3.Lerp(crouch, stand, Time.deltaTime * 100f);
        crouching = false;
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
